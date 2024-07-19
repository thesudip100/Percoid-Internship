using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GharSewaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookservice;

        public BookingController(IBookingService bookservice)
        {
            _bookservice = bookservice;
        }

        [HttpPost,Authorize(Roles ="User")]
        public async Task<IActionResult> BookService(BookingDTO booking)
        {
            var result = await _bookservice.BookServiceAsync(booking, User);
            return Ok(result);
        }
    }
}
