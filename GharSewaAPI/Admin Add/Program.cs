using Dapper;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

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

    static void Main(string[] args)
    {
        string adminUsername = "theadmin100";
        string adminPassword = "admin100";
        string adminRole = "Admin";

        HashPassword(adminPassword, out byte[] passwordSalt, out byte[] passwordHash);

        string connectionString = "Server=DESKTOP-SUDIP\\SQLEXPRESS; Database=GharSewaDatabase;  Trusted_Connection=True; TrustServerCertificate= True;";

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            var adminCheckQuery = "SELECT COUNT(1) FROM AuthUsers WHERE UserName = @UserName";
            bool isAdminExists = connection.ExecuteScalar<bool>(adminCheckQuery, new { UserName = adminUsername });

            if (!isAdminExists)
            {
                var insertAdminQuery = "INSERT INTO AuthUsers (UserName, PassWordSalt, PassWordHash, Role) VALUES (@UserName, @PassWordSalt, @PassWordHash, @Role)";
                connection.Execute(insertAdminQuery, new
                {
                    UserName = adminUsername,
                    PassWordSalt = passwordSalt,
                    PassWordHash = passwordHash,
                    Role = adminRole
                });

                Console.WriteLine("Admin user created successfully.");
            }
            else
            {
                Console.WriteLine("Admin user already exists.");
            }
        }
    }
}
