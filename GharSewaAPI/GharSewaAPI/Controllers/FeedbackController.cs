using ApplicationLayer.Services.Service;
using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GharSewaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        [HttpPost, Authorize(Roles="User")]
        public async Task<IActionResult> AddFeedbacks(feedbackDTO feedback)
        {
            var result = await _service.AddFeedbackAsync(feedback, User);
            return Ok(new { message = $"{result}" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeedbacks()
        {
            var result = await _service.GetAllFeedbacksAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbacks(int id)
        {
            var result= await _service.DeleteFeedbacks(id);
            return Ok(new { message = $"{result}" });
        }
    }
}
