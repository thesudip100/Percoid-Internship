using Dapper;
using DomainLayer.DTO;
using DomainLayer.Interface;
using Microsoft.Data.SqlClient;
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
                var bookingQuery = "INSERT INTO Bookings(ServiceName, BookingDate) VALUES(@ServiceName, @BookingDate); SELECT SCOPE_IDENTITY();";
                var bookingId = await connection.ExecuteScalarAsync<int>(bookingQuery, new
                {
                    @ServiceName = booking.ServiceName,
                    @BookingDate = booking.BookingDate
                });

                var userBookingQuery = "INSERT INTO UserBookings(UserId, BookingId) VALUES(@UserId, @BookingId)";
                await connection.ExecuteAsync(userBookingQuery, new
                {
                    @UserId = userId,
                    @BookingId = bookingId
                });

                return "Booking successful";
            }
        }

        private int GetUserIdFromToken(ClaimsPrincipal user)
        {
            if (user.HasClaim(c => c.Type == "UserId"))
            {
                return int.Parse(user.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);
            }
            throw new Exception("User ID not found in token");
        }

    }
}
