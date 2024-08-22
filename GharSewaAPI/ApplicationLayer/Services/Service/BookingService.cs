using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Entities;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Service
{
    public class BookingService:IBookingService
    {
        private readonly IBookingRepository _bookrepo;

        public BookingService(IBookingRepository bookrepo)
        {
            _bookrepo = bookrepo;
        }

        public Task<AdminStatsDTO> AdminStatsAsync()
        {
            return _bookrepo.AdminStatsAsync();
        }

        public Task<string> ApproveBookingsAsync(int bookid)
        {
            return _bookrepo.ApproveBookingsAsync(bookid);
        }

        public Task<string> BookServiceAsync(BookingDTO booking, ClaimsPrincipal user)
        {
            return _bookrepo.BookServiceAsync(booking, user);
        }

        public Task<string> DeletebookingAsync(int bookid)
        {
            return _bookrepo.DeletebookingAsync(bookid);
        }

        public Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            return _bookrepo.GetAllBookingsAsync();
        }

        public Task<IEnumerable<BookingDTO>> GetAllUnapprovedBookingsAsync()
        {
            return _bookrepo.GetAllUnapprovedBookingsAsync();
        }

        public Task<Booking> GetBookingbyBookingIdAsync(int bookId)
        {
            return _bookrepo.GetBookingbyBookingIdAsync(bookId);
        }

        public Task<IEnumerable<BookingDTO>> GetBookingByUserIdAsync(int id)
        {
            return _bookrepo.GetBookingByUserIdAsync(id);
        }

        public Task<string> GetBookingStatusAsync(int bookid)
        {
            return _bookrepo.GetBookingStatusAsync(bookid);
        }

        public Task<string> UpdateBookingDetailsAsync(BookingDTO booking, int book)
        {
            return _bookrepo.UpdateBookingDetailsAsync(booking, book);
        }
    }
}
