using AutoMapper;
using Dapper;
using DomainLayer.DTOs;
using DomainLayer.Entities;
using DomainLayer.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;

        public UserRepository(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _mapper = mapper;
        }

        public async Task<string> CreateUser(UserRegisterDTO user)
        {
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var add = _mapper.Map<User>(user);
            add.PasswordHash = passwordHash;
            add.PasswordSalt = passwordSalt;

            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Users (FullName, Address, PhoneAddress, EmailAddress, UserName, ProfilePicURL, PasswordHash, PasswordSalt) " +
                            "VALUES (@FullName, @Address, @PhoneAddress, @EmailAddress, @UserName, @ProfilePicURL, @PasswordHash, @PasswordSalt)";
                await connection.ExecuteAsync(query, add);
                return "Added";
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
