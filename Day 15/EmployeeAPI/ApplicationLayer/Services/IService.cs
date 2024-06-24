using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllDataAsync();
        Task<T> GetByIdDataAsync(int id);
        Task AddDataAsync(T entity);
        Task UpdateDataAsync(T entity);
        Task DeleteDataAsync(int id);
    }
}
