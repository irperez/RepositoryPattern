using Microsoft.EntityFrameworkCore;
using NRepository.MyTestBL.Models;

namespace NRepository.MyTestBL.BL.DataAccess
{
    public class MyTestContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        public MyTestContext(DbContextOptions<MyTestContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();

            base.OnModelCreating(modelBuilder);
        }
    }
}
