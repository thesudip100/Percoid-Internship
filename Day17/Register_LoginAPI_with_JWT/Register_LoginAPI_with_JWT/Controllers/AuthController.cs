using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Register_LoginAPI_with_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration configuration;

        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult CreateUser(UserDTO userDTO)
        {
            user.username = userDTO.UserName;
            HashPassword(userDTO.Password, out byte[] passHash, out byte[] passSalt);
            user.PasswordHash = passHash;
            user.PasswordSalt = passSalt;
            return Ok(user);
        }

        private void HashPassword(string password, out byte[] passwordash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        [HttpPost("login")]
        public IActionResult LoginUser(UserDTO userDTO)
        {
            if (user.username != userDTO.UserName)
            {
                return BadRequest("Username is not found in our database");
            }
            if (!VerifyPassword(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Password not match");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("username", user.username)
            };

            var secretKey = configuration["ApplicationSettings:secret_key"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Application secret key is not configured.");
            }
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature)
        );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

    }
}