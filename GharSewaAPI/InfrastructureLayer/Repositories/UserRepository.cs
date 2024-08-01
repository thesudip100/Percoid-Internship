using Dapper;
using DomainLayer.DTO;
using DomainLayer.Entities;
using DomainLayer.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

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

       

        public async Task<string> CreateUserAsync(UserRegisterDTO user)
        {
            HashPassword(user.PassWord, out byte[] PassSalt, out byte[] PassHash);
            using (var connection = new SqlConnection(connectionString))
            {
                var usernamecheck_query = "select count(1) from AuthUsers where UserName=@UserName";
                var username = await connection.ExecuteScalarAsync<bool>(usernamecheck_query, new
                {
                    @UserName = user.UserName
                });
                if (username)
                {
                    return "Username already exists";
                }
                else
                {
                    var auth_table_query = "INSERT INTO AuthUsers(UserName, PassWordSalt, PassWordHash, Role) values( @UserName, @PassWordSalt, @PassWordHash, @Role)";
                    var authId = await connection.ExecuteAsync(auth_table_query, new
                    {
                        @UserName = user.UserName,
                        @PassWordSalt = PassSalt,
                        @PassWordHash = PassHash,
                        @Role = "User"
                    });

                    var usertable_query = "INSERT INTO Users(FullName, Address, Email, Phone) values(@FullName, @Address, @Email, @Phone)";
                    await connection.ExecuteAsync(usertable_query, new
                    {
                        @FullName = user.FullName,
                        @Address = user.Address,
                        @Email = user.Email,
                        @Phone = user.Phone,
                    });
                    return "User Registered Successfully! Please Login Now";
                }

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


        private string CreateToken(AuthUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName ),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.SerialNumber, user.AuthId.ToString())
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



        public async Task<string> EditUserProfileAsync(EditUserDTO user, int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //can edit own username but cannot put username that already exists in the database
                var usernameCheck_query = "select count(1) from AuthUsers where UserName=@UserName and AuthId!=@Id";
                var result = await connection.ExecuteScalarAsync<bool>(usernameCheck_query, new
                {
                    @UserName = user.UserName,
                    @Id = id
                });


                if (result)
                {
                    return "Username Already Exists";
                }

                else
                {
                    var query_first = "UPDATE Users set FullName=@FullName, Address=@Address, Email=@Email, Phone=@Phone where UserId=@Id";

                    var query_second = "UPDATE AuthUsers set UserName=@UserName where AuthId=@Id";

                    await connection.ExecuteAsync(query_first, new
                    {
                        @FullName = user.FullName,
                        @Address = user.Address,
                        @Email = user.Email,
                        @Phone = user.Phone,
                        @Id = id
                    });

                    await connection.ExecuteAsync(query_second, new
                    {
                        @UserName = user.UserName,
                        @Id = id
                    });
                    return "Profile Edited Successfully";
                }
            }
        }




        public async Task<EditUserDTO> GetUserbyIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select a.UserName, u.FullName, u.Address, u.Email, u.Phone from AuthUsers a join Users u on a.AuthId=u.UserId where a.AuthId=@Id";
                var response = await connection.QueryFirstOrDefaultAsync<EditUserDTO>(query, new
                {
                    @Id = id
                });
                return response;
            }
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var queryFirst = "delete from AuthUsers where AuthId=@Id";
                await connection.ExecuteAsync(queryFirst, new
                {
                    @Id = id
                });

                var querySecond = "delete from Users where UserId=@Id";
                await connection.ExecuteAsync(querySecond, new
                {
                    @Id = id
                });

                var deleteBookingsQuery = @"
                    DELETE FROM Bookings 
                    WHERE BookingId IN (
                        SELECT BookingId FROM UserBookings WHERE UserId = @Id
                    )";
                await connection.ExecuteAsync(deleteBookingsQuery, new { Id = id });

                var deleteUserBookingsQuery = "DELETE FROM UserBookings WHERE UserId = @Id";
                await connection.ExecuteAsync(deleteUserBookingsQuery, new { Id = id });

            }
            return "User deleted successfully";
        }


        public async Task<string> ChangePasswordAsync(ChangePasswordDTO user, int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select * from AuthUsers where AuthId=@Id";
                var data = await connection.QueryFirstOrDefaultAsync<AuthUser>(query, new { @Id = id });
                if (data != null)
                {
                    if (CheckPassword(user.oldPassword, data.PasswordSalt, data.PassWordHash))
                    {
                        HashPassword(user.newPassword, out byte[] passSalt, out byte[] passHash);
                        var query_changepass = "Update AuthUsers set PassWordHash=@passhash, PasswordSalt=@passsalt where AuthId=@Id";
                        await connection.ExecuteAsync(query_changepass, new
                        {
                            @passhash = passHash,
                            @passsalt = passSalt,
                            @Id = id
                        });
                        return "Password change success";
                    }
                    else
                    {
                        return "Password didnt match, try again";
                    }

                }
                else
                {
                    return "User not found";
                }
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

        private void HashPassword(string password, out byte[] passSalt, out byte[] passHash)
        {
            using (var hmac = new HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }



        /* public async Task<string> OTPGenerationAsync(OTPGenerationDTO user)
         {
             using (var connection = new SqlConnection(connectionString))
             {
                 var check_usernamequery = "select count(1) from AuthUsers where UserName=@UserName";
                 var data = await connection.ExecuteScalarAsync<bool>(check_usernamequery, new { @Username = user.UserName });
                 if (!data)
                 {
                     return "Username/Email is not Found";
                 }
                 else
                 {
                     var otp = GenerateOTP();
                     var expirationTime = DateTime.UtcNow.AddMinutes(5);
                     var cacheEntryOptions = new MemoryCacheEntryOptions
                     {
                         AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                     };
                     _cache.Set(user.UserName, otp, cacheEntryOptions);
                     await SendEmailAsync(user.Email, otp);
                     return "OTP has been sent to your email.";
                 }
             }

         }*/

        /*  private string GenerateOTP()
          {
              Random random = new Random();
              return random.Next(100000, 999999).ToString();
          }

          private async Task SendEmailAsync(string email, string otp)
          {
              var toEmail = email;
              var subject = "Your OTP Code";
              var body = $"Your OTP code is: {otp}";

              var smtpClient = new SmtpClient(_email.SmtpServer)
              {
                  Port = Convert.ToInt32(_email.SmtpPort),
                  Credentials = new NetworkCredential(_email.SenderEmail, _email.SenderPassword),
                  EnableSsl = true,
                  DeliveryMethod = SmtpDeliveryMethod.Network,
                  UseDefaultCredentials = false 
              };

              var mailMessage = new MailMessage
              {
                  From = new MailAddress(_email.SenderEmail, _email.SenderName),
                  Subject = subject,
                  Body = body,
                  IsBodyHtml = false,
              };
              mailMessage.To.Add(toEmail);

              await smtpClient.SendMailAsync(mailMessage);
          }*/



    }
}
