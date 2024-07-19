using DomainLayer.DTO;
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
    }
}
