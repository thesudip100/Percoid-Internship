using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<AuthUser>AuthUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking>Bookings { get; set; }
        public DbSet<UserBooking> UserBookings { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ServiceCategory> Categories { get; set; }
    }
}
