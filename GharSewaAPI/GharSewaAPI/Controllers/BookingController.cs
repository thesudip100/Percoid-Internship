﻿using ApplicationLayer.Services.Service_Interface;
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
        public async Task<IActionResult> getAdminStats()
        {
            var result = await _bookservice.AdminStatsAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookingsbyBookingId(int bookid)
        {
            var result = await _bookservice.GetBookingbyBookingIdAsync(bookid);
            return Ok(result);
        }

        [HttpGet, Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUnapprovedBookings()
        {
            var result = await _bookservice.GetAllUnapprovedBookingsAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingsbyUserId(int id)
        {
            var result = await _bookservice.GetBookingByUserIdAsync(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookingDetailsAsync(BookingDTO booking, int bookid)
        {
            var result= await _bookservice.UpdateBookingDetailsAsync(booking, bookid);
            return Ok(result);
        }

        [HttpDelete("{bookid}")]
        public async Task<IActionResult> DeleteBookingDetailsAsync(int bookid)
        {
            var result = await _bookservice.DeletebookingAsync(bookid);
            return Ok(new { message = $"{result}" });
        }

        [HttpGet("{bookid}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveBookingsAsync(int bookid)
        {
            var result= await _bookservice.ApproveBookingsAsync(bookid);
            return Ok(new { message = $"{result}" });
        }

        [HttpGet("{bookid}")]
        public async Task<IActionResult> GetBookingStatusAsync(int bookid)
        {
            var result= await _bookservice.GetBookingStatusAsync(bookid);
            return Ok(new { message = $"{result}" });
        }




    }
}
