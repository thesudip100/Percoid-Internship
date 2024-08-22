using Microsoft.EntityFrameworkCore;

namespace FHIR_NEW.Data_Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PatientModel> PatientsDetail {  get; set; }
    }
}
