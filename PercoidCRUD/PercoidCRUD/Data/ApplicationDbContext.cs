using Microsoft.EntityFrameworkCore;
using PercoidCRUD.Models;

namespace PercoidCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Intern> Intern { get; set; }
    }
    
}
