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
            var response=await _service.RegisterUserAsync(user);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginDTO user)
        {
            var response = await _service.UserLoginAsync(user);
            return Ok(new { message = $"{response}" });
        }

        [HttpPut]
        public async Task<IActionResult> EditUserProfile(EditUserDTO user, int id)
        {
            var response = await _service.EditUserProfileAsync(user, id);
            return Ok(new { message = response });
        }

        [HttpGet]
        public async Task<IActionResult> GetSingleUser(int id)
        {
            var response= await _service.GetUserbyIdAsync(id);
            if(response == null)
            {
                return Ok(new { message = "User not Found" });
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response= await _service.DeleteUserAsync(id);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO user, int id)
        {
            var response = await _service.ChangePasswordAsync(user, id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> OTPGeneration(OTPGenerationDTO user)
        {
            var response = await _service.OTPGenerationAsync(user);
            return Ok(response);
        }

    }
}

