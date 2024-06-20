using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer_Services_.Services
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAllData();
        T GetDataByID(int id);
        void AddData(T t);
        void UpdateData(T t);
        void DeleteData(T t);
    }
}
