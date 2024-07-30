using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Entities;
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

        [HttpPost, Authorize(Roles = "User")]
        public async Task<IActionResult> BookService(BookingDTO booking)
        {
            var result = await _bookservice.BookServiceAsync(booking, User);
            return Ok(new { message = $"{result}" });

        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> getAllBookings()
        {
            var result = await _bookservice.GetAllBookingsAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingsbyBookingId(int bookid)
        {
            var result = await _bookservice.GetBookingbyBookingIdAsync(bookid);
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingsbyUserId(int id)
        {
            var result = await _bookservice.GetBookingByUserIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookingDetailsAsync(BookingDTO booking, int bookid)
        {
            var result= await _bookservice.UpdateBookingDetailsAsync(booking, bookid);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBookingDetailsAsync(int bookid)
        {
            var result = await _bookservice.DeletebookingAsync(bookid);
            return Ok(result);
        }




    }
}
