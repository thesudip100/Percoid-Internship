using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper; // Make sure to include Dapper

class Program
{
    private static void HashPassword(string password, out byte[] passSalt, out byte[] passHash)
    {
        using (var hmac = new HMACSHA512())
        {
            passSalt = hmac.Key;
            passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    static async Task Main(string[] args)
    {
        string adminUsername = "theadmin100";
        string adminPassword = "admin100";
        string adminRole = "Admin";

        // Additional user details
        string fullName = "Admin";
        string address = "Shankhamul";
        string email = "agharsewa@gmail.com";
        string phone = "9868207566";

        HashPassword(adminPassword, out byte[] passwordSalt, out byte[] passwordHash);

        string connectionString = "Server=DESKTOP-SUDIP\\SQLEXPRESS; Database=GharSewaDatabase; Trusted_Connection=True; TrustServerCertificate=True;";

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

            // Check if the user exists in AuthUsers
            var adminCheckQuery = "SELECT COUNT(1) FROM AuthUsers WHERE UserName = @UserName";
            bool isAdminExists = await connection.ExecuteScalarAsync<bool>(adminCheckQuery, new { UserName = adminUsername });

            if (!isAdminExists)
            {
                // Insert into AuthUsers table
                var insertAuthUsersQuery = @"
                    INSERT INTO AuthUsers (UserName, PassWordSalt, PassWordHash, Role) 
                    VALUES (@UserName, @PassWordSalt, @PassWordHash, @Role)";
                await connection.ExecuteAsync(insertAuthUsersQuery, new
                {
                    UserName = adminUsername,
                    PassWordSalt = passwordSalt,
                    PassWordHash = passwordHash,
                    Role = adminRole
                });

                // Insert into Users table
                var insertUsersQuery = @"
                    INSERT INTO Users ( FullName, Address, Email, Phone) 
                    VALUES (@FullName, @Address, @Email, @Phone)";
                await connection.ExecuteAsync(insertUsersQuery, new
                {
                    FullName = fullName,
                    Address = address,
                    Email = email,
                    Phone = phone
                });

                Console.WriteLine("Admin user and details created successfully.");
            }
            else
            {
                Console.WriteLine("Admin user already exists.");
            }
        }
    }
}
