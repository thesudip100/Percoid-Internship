using DomainLayer.DTO;
using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IBookingRepository
    {
        public Task<string> BookServiceAsync(BookingDTO booking, ClaimsPrincipal user);
        public Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        public Task<BookingDTO> GetBookingbyBookingIdAsync(int bookId);
        public Task<BookingDTO> GetBookingByUserIdAsync(int userId);
        public Task<string> DeletebookingAsync(int bookid);
        public Task<string> UpdateBookingDetails(BookingDTO booking);
    }
}
