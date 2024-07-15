using Azure;
using Dapper;
using DomainLayer.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace InfrastructureLayer.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly string _connectionString;

        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<string> AddAsync(Customer entity)
        {
            using(var connection=new SqlConnection(_connectionString))
            {
                string response = "added";
                var query = "Insert into Customer (Id,Name,Email,Phone,Address) values (@Id,@Name,@Email,@Phone,@Address)";
                await connection.ExecuteAsync(query, entity);
                return response;
            }
        }

        public async Task<string> DeleteAsync(Customer entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string response = "deleted";
                var query = "DELETE FROM Customer WHERE Id = @Id";
                await connection.ExecuteAsync(query, new { entity.Id });
                return response;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "select * from Customer";
            var entities = await connection.QueryAsync<Customer>(query);
            return entities.ToList();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "select * from Customer WHERE Id = @Id";
                var entity = await connection.QuerySingleOrDefaultAsync<Customer>(query, new { @Id = id });
                if (entity != null)
                    return entity;
                else
                    throw new Exception("Entity not Found");
            }

        }


        public async Task UpdateAsync(Customer entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "update Customer set Name=@Name,Email=@Email,Phone=@Phone, Address=@Address WHERE Id = @Id";
                await connection.ExecuteAsync(query, new
                {
                    @Name=entity.Name,
                    @Email=entity.Email,
                    @Phone=entity.Phone,
                    @Address=entity.Address,
                    @Id=entity.Id
                });
            }
        }
    }
}
