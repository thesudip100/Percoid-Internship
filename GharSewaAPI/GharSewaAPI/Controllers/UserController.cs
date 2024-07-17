using ApplicationLayer.Services.Service_Interface;
using DomainLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GharSewaAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult> UserRegistration(UserRegisterDTO user)
        {
            await _service.RegisterUserAsync(user);
            return Ok(new {message="User registered successfully"});
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDTO user)
        {
            var response = await _service.UserLoginAsync(user);
            return Ok(new { message = $"User logged in successfully, {response}" });
        }
    }
}
