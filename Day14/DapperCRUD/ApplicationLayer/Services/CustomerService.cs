using DomainLayer.Entities;
using InfrastructureLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace ApplicationLayer.Services
{
    public class CustomerService:IService<Customer>
    {
        private readonly IRepository<Customer> repository;

        public CustomerService(IRepository<Customer> _repository)
        {
            repository = _repository;
        }

        public Task<string> AddDataAsync(Customer entity)
        {
            return repository.AddAsync(entity);
        }

        public Task<string> DeleteDataAsync(Customer entity)
        {
            return repository.DeleteAsync(entity);
        }

        public Task<IEnumerable<Customer>> GetAllDataAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<Customer> GetByIdDataAsync(int id)
        {
            return repository.GetByIdAsync(id);
        }

        public Task<string> UpdateDataAsync(Customer entity)
        {
            return repository.UpdateAsync(entity);
        }
    }
}
