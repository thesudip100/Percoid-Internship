using DomainLayer.DTO;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.Service_Interface
{
    public interface IBookingService
    {
        public Task<string> BookServiceAsync(BookingDTO booking, ClaimsPrincipal user);
        public Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        public Task<Booking> GetBookingbyBookingIdAsync(int bookId);
        public Task<IEnumerable<BookingDTO>> GetBookingByUserIdAsync(int id);
        public Task<string> DeletebookingAsync(int bookid);
        public Task<string> UpdateBookingDetailsAsync(BookingDTO booking, int bookid);
    }
}
