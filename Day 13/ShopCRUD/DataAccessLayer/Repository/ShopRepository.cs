using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ShopRepository : IRepository<Shop>
    {
        private readonly ApplicationDbContext context;

        public ShopRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async void Add(Shop entity)
        {
            await context.AddAsync(entity);
            context.SaveChanges();
        }

        public  void Update(Shop entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Shop entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Shop> GetAll()
        {
            return context.Set<Shop>().ToList();
        }

        public Shop GetByID(int id)
        {
            return context.Set<Shop>().Find(id);
        }
    }
}
