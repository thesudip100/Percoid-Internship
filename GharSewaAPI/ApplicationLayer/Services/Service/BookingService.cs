using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
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
        public Task<string> BookServiceAsync(BookingDTO booking, ClaimsPrincipal user)
        {
            return _bookrepo.BookServiceAsync(booking, user);
        }
    }
}
