using LOGINPage.Models;
using Microsoft.EntityFrameworkCore;

namespace LOGINPage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User>Users { get; set; }
    }
}
