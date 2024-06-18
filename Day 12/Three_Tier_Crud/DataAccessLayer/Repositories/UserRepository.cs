using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Set<User>().ToList();
        }

        public User? GetById(int id)
        {
            return context.Set<User>().Find(id);
        }

        public void Add(User entity)
        {
            context.Set<User>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            context.Set<User>().Remove(entity);
            context.SaveChanges();
        }


        public void Update(User entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

