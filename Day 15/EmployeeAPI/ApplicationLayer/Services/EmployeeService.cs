using DomainLayer.Entities;
using DomainLayer.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class EmployeeService : IService<Employee>
    {
        private readonly IRepository<Employee> repository;

        public EmployeeService(IRepository<Employee> _repository)
        {
            repository = _repository;
        }
        public async Task AddDataAsync(Employee entity)
        {
              await repository.AddAsync(entity);
        }

        public async Task DeleteDataAsync(int id)
        {
            await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAllDataAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<Employee> GetByIdDataAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task UpdateDataAsync(Employee entity)
        {
            await repository.UpdateAsync(entity);
        }
    }
}
