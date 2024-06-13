using CustomerCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer>Customers { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<CustomerGoods> CustomerGoods { get; set; }
    }
}
