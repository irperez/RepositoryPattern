using Microsoft.EntityFrameworkCore;
using NRepository.UniversityBL.Domain;

namespace NRepository.UniversityBL.BL.DataAccess
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        public UniversityContext(DbContextOptions<UniversityContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();

            base.OnModelCreating(modelBuilder);
        }
    }
}
