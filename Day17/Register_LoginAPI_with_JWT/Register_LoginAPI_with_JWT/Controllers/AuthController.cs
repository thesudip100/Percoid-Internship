using Microsoft.AspNetCore.Authorization;
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
        
        public static User admin = new User
        {
            username = "theadmin100",
            role = "Admin"
        };

        static AuthController()
        {
            HashPassword("admin100", out byte[] passHash, out byte[] passSalt);
            admin.PasswordHash = passHash;
            admin.PasswordSalt = passSalt;
        }


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
            user.role = "User";
            return Ok(user);
        }

        private static void HashPassword(string password, out byte[] passwordash, out byte[] passwordSalt)
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
            User loginUser;
            if (admin.username == userDTO.UserName)
            {
                
                loginUser = admin;
            }
            else if (user.username == userDTO.UserName)
            {
                loginUser = user;
            }
            else
            {
                return BadRequest("Username is not found in our database");
            }

            if (!VerifyPassword(userDTO.Password, loginUser.PasswordHash, loginUser.PasswordSalt))
            {
                return BadRequest("Password not match");
            }
            string token = CreateToken(loginUser);
            return Ok(token);
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Role, user.role)
            };

            var secretKey = configuration["ApplicationSettings:secret_key"];

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Application secret key is not configured.");
            }
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature)
        );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admindash")]
        public IActionResult AdminOnlyEndpoint()
        {
            // Only accessible by users with "Admin" role
            return Ok("Admin endpoint accessed");
        }

        [Authorize(Roles = "User")]
        [HttpGet("userdash")]
        public IActionResult UserOnlyEndpoint()
        {
            // Only accessible by users with "Admin" role
            return Ok("User endpoint accessed");
        }
    }
}