using DataAccessLayer.Entity;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer_Services_.Services
{
    public class ShopService : IService<Shop>
    {
        private readonly IRepository<Shop> shoprepository;

        public ShopService(IRepository<Shop> _shoprepository)
        {
            shoprepository = _shoprepository;
        }

        public IEnumerable<Shop> GetAllData()
        {
            return shoprepository.GetAll();
        }

        public Shop GetDataByID(int id)
        {
            return shoprepository.GetByID(id);
        }

        public void AddData(Shop shop)
        {
            shoprepository.Add(shop);
        }

        public void UpdateData(Shop shop)
        {
            shoprepository.Update(shop);
        }

        public void DeleteData(Shop shop)
        {
            shoprepository.Delete(shop);
        }
    }
}
