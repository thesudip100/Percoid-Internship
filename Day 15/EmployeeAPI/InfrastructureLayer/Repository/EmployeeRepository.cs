using Dapper;
using DomainLayer.Entities;
using DomainLayer.RepoInterface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly string _connectionstring;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddAsync(Employee entity)
        {
            using( var connection= new SqlConnection(_connectionstring))
            {
                var query = "Insert into Employees(Id,empName,empAddress,empPhone) values (@Id,@empName, @empAddress, @empPhone)";
                await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            using( var connection= new SqlConnection(_connectionstring))
            {
                var query = "Delete from Employees where Id=@Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            using(var connection= new SqlConnection(_connectionstring))
            {
                var query = "SELECT * FROM Employees";
                var employees= await connection.QueryAsync<Employee>(query);
                return employees.ToList();
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                var query = "SELECT * FROM Employees where Id=@Id";
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(query, new {Id=id});
                return employee;
            }
        }

        public async Task UpdateAsync(Employee entity)
        {
            using (var connection=new SqlConnection(_connectionstring))
            {
                var query = "update Employees set empName=@empName,empAddress=@empAddress,empPhone=@empPhone where Id=@Id" ;
                await connection.ExecuteAsync(query, new {
                    entity.empName,
                    entity.empAddress,
                    entity.empPhone,
                    entity.Id
                });
            }
        }
    }
}
