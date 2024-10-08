﻿using Dapper;
using DomainLayer.DTO;
using DomainLayer.Entities;
using DomainLayer.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public BookingRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            this.configuration = configuration;
        }


        public async Task<string> BookServiceAsync(BookingDTO booking, ClaimsPrincipal user)
        {
            var userId = GetUserIdFromToken(user);

            using (var connection = new SqlConnection(connectionString))
            {
                var bookingQuery = "INSERT INTO Bookings(ServiceName, BookingDate,BookingApproval) VALUES(@ServiceName, @BookingDate, @status); SELECT SCOPE_IDENTITY();";
                var bookingId = await connection.ExecuteScalarAsync<int>(bookingQuery, new
                {
                    @ServiceName = booking.ServiceName,
                    @BookingDate = booking.BookingDate,
                    @status=false
                });

                var userBookingQuery = "INSERT INTO UserBookings(UserId, BookingId) VALUES(@UserId, @BookingId)";
                await connection.ExecuteAsync(userBookingQuery, new
                {
                    @UserId = userId,
                    @BookingId = bookingId
                });

                return "Booking sent!! Confirmation pending from admin";
            }
        }


        private int GetUserIdFromToken(ClaimsPrincipal user)
        {
            if (user.HasClaim(c => c.Type == ClaimTypes.SerialNumber))
            {
                return int.Parse(user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber)?.Value);
            }
            throw new Exception("User ID not found in token");
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select u.FullName, u.Address, u.phone, b.ServiceName, b.BookingDate, b.BookingId from Users u join UserBookings ub on u.UserId=ub.UserId join Bookings b on b.BookingId=ub.BookingId where b.BookingApproval=@status order by b.BookingId desc";
                var entities = await connection.QueryAsync<BookingDTO>(query, new
                {
                    status=true
                });
                return entities.ToList();
            }
        }

        public async Task<Booking> GetBookingbyBookingIdAsync(int bookId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select * from Bookings where BookingId=@Id";
                var entity = await connection.QueryFirstOrDefaultAsync<Booking>(query, new { @Id = bookId });
                return entity;
            }
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingByUserIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select u.FullName, u.Address, u.phone, b.ServiceName, b.BookingDate, b.bookingId, b.BookingApproval from Users u join UserBookings ub on u.UserId=ub.UserId join Bookings b on b.BookingId=ub.BookingId where u.UserId=@Id order by b.BookingId desc";
                var entities = await connection.QueryAsync<BookingDTO>(query, new { @Id = id });
                return entities.ToList();
            }
        }

        public async Task<string> DeletebookingAsync(int bookid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var count_query = "select count(1) from Bookings where BookingId=@Id";
                var result = await connection.ExecuteScalarAsync<bool>(count_query, new { @Id = bookid });
                if (result)
                {
                    var del_query1 = "Delete from UserBookings where BookingId=@Id";
                    await connection.ExecuteAsync(del_query1, new { @Id = bookid });

                    var del_query2 = "Delete from Bookings where BookingId=@Id";
                    await connection.ExecuteAsync(del_query2, new { @Id = bookid });

                    return "Successfully deleted";
                }
                else
                {
                    return "Booking Id not found";
                }
            }
        }

        public async Task<string> UpdateBookingDetailsAsync(BookingDTO booking, int bookid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var update_query = "UPDATE Bookings set ServiceName=@servicename, BookingDate=@bookingdate where BookingId=@Id";
                await connection.ExecuteAsync(update_query, new
                {
                    @servicename = booking.ServiceName,
                    @bookingdate = booking.BookingDate,
                    @Id = bookid
                });
                return "Updated successfully";
            }
        }

        public async Task<string> ApproveBookingsAsync(int bookid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var approvalquery = "UPDATE Bookings set BookingApproval=@status where BookingId=@Id";
                await connection.ExecuteAsync(approvalquery, new
                {
                    @status = true,
                    @Id = bookid
                });
                return "Successfully approved";
            }
        }


        public async Task<string> GetBookingStatusAsync(int bookid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var statusquery = "SELECT BookingApproval from Bookings where BookingId=@Id";
                var data = await connection.QuerySingleOrDefaultAsync<bool?>(statusquery, new { Id = bookid });

                if (data == true)
                {
                    return "Booking Approved";
                }
                else
                {
                    return "Pending Approval";
                }
            }
        }

        public async Task<IEnumerable<BookingDTO>> GetAllUnapprovedBookingsAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select u.FullName, u.Address, u.phone, b.ServiceName, b.BookingDate, b.BookingId, b.BookingApproval from Users u join UserBookings ub on u.UserId=ub.UserId join Bookings b on b.BookingId=ub.BookingId where b.BookingApproval=@status order by b.BookingId desc";
                var entities = await connection.QueryAsync<BookingDTO>(query, new
                {
                    status=false
                });
                return entities.ToList();
            }
        }

        public async Task<AdminStatsDTO> AdminStatsAsync()
        {
            using(var connection = new SqlConnection(connectionString))
            {
                var query1 = "SELECT COUNT(*) from Bookings where BookingApproval=@status";
                var approvedBookingsCount=await connection.ExecuteScalarAsync<int>(query1, new {status=true});

                var query2 = "SELECT COUNT(*) from Bookings where BookingApproval=@status";
                var UnapprovedBookingsCount = await connection.ExecuteScalarAsync<int>(query2, new { status = false });

                var query3 = "SELECT COUNT(*) from Categories";
                var CategoryCount = await connection.ExecuteScalarAsync<int>(query3);

                return new AdminStatsDTO
                {
                    ApprovedBookingsCount = approvedBookingsCount,
                    UnapprovedBookingsCount = UnapprovedBookingsCount,
                    CategoryCount = CategoryCount
                };
            }
        }
    }
}

