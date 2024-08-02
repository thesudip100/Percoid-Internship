using Dapper;
using DomainLayer.DTO;
using DomainLayer.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class ServiceCategoryRepository : ICategoryRepository
    {
        private readonly string connectionString;

        public ServiceCategoryRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<ServiceCategoryDTO>> GetAllAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select * from Categories";
                var entities = await connection.QueryAsync<ServiceCategoryDTO>(query);
                return entities.ToList();
            }
        }

        public async Task<string> AddCategoryAsync(ServiceCategoryDTO categoryDTO)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Categories (CategoryName) VALUES (@name)";
                var response = await connection.ExecuteAsync(query, new
                {
                    @name = categoryDTO.categoryname
                });
            }
            return "New Service added successfully";
        }

    }
}
