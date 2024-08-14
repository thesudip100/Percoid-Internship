using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FHIR_API.Data_Access
{

        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions options) : base(options)
            {
            }

            public DbSet<PatientDetail> Patients { get; set; }
        }
    }
