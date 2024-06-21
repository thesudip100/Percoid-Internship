using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public interface IRepository<T> where T : class
    {
        Task <IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<string> AddAsync(T entity);
        Task<string> UpdateAsync(T entity);
        Task<string> DeleteAsync(T entity);
    }
}
