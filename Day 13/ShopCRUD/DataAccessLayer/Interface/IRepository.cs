using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
