using Dapper;
using DomainLayer.DTO;
using DomainLayer.Entities;
using DomainLayer.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            this.configuration = configuration;
        }

        public async Task CreateUserAsync(UserRegisterDTO user)
        {
            HashPassword(user.PassWord, out byte[] PassSalt, out byte[] PassHash);
            using (var connection = new SqlConnection(connectionString))
            {
                var auth_table_query = "INSERT INTO AuthUsers(UserName, PassWordSalt, PassWordHash, Role) OUTPUT INSERTED.AuthId values( @UserName, @PassWordSalt, @PassWordHash, @Role)";
                var authId = await connection.QuerySingleAsync<int>(auth_table_query, new
                {
                    @UserName = user.UserName,
                    @PassWordSalt = PassSalt,
                    @PassWordHash = PassHash,
                    @Role = "User"
                });

                var usertable_query = "INSERT INTO Users(FullName, Address, Email, Phone, AuthId) values(@FullName, @Address, @Email, @Phone, @AuthId)";
                await connection.ExecuteAsync(usertable_query, new
                {
                    @FullName = user.FullName,
                    @Address = user.Address,
                    @Email = user.Email,
                    @Phone = user.Phone,
                    @AuthId = authId
                });

            }
        }

        public async Task<string> LoginUserAsync(LoginDTO user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT count(*) from AuthUsers where UserName=@UserName";
                var result = connection.ExecuteScalar<bool>(query, user);
                if (result)
                {
                    var querySecond = "SELECT * from AuthUsers where UserName=@UserName";
                    var data = await connection.QueryFirstOrDefaultAsync<AuthUser>(querySecond, new
                    {
                        @UserName = user.UserName
                    });
                    if (data != null)
                    {
                        if (CheckPassword(user.PassWord, data.PasswordSalt, data.PassWordHash))
                        {
                            string token = CreateToken(data);
                            return token;
                        }
                        else
                        {
                            return "Incorrect Password";
                        }

                    }
                    else
                    {
                        return "No value received";
                    }

                }
                else
                {
                    return "Username not Found";
                }

            }
        }

        private void HashPassword(string password, out byte[] passSalt, out byte[] passHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool CheckPassword(string password, byte[] passSalt, byte[] passHash)
        {
            using (var hmac = new HMACSHA512(passSalt))
            {
                var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedPass.SequenceEqual(passHash);
            }
        }

        private string CreateToken(AuthUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName ),
                new Claim(ClaimTypes.Role, user.Role)
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
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
        );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
