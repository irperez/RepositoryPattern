using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NRepository.Persistence.Infrastructure
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {

        private string _ConnectionStringName = "MyTestDatabase";
        protected virtual string ConnectionStringName
        {
            get { return _ConnectionStringName; }
            set { _ConnectionStringName = value; }
        }

        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        public TContext CreateDbContext(string[] args)
        {
             

            //Add-Migration InitialCreate -project 'University.Data' -startupproject 'NRepository.RazorPages' -Context UniversityContext -OutputDir Migrations\SqlServerMigrations
            //update-database -project 'University.Data' -startupproject 'NRepository.RazorPages'
            //Remove-Migration -project 'University.Data' -startupproject 'NRepository.RazorPages'


            //InitialCreate -Context MyDbContext -OutputDir Migrations\SqlServerMigrations
            //https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers
            //https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/
            var di = new DirectoryInfo(Directory.GetCurrentDirectory());

            string basePath = di.Parent.ToString();
            //var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}Northwind.WebUI", Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environmentName)
        {
            //This section will need to change if you are using ConfigurationManager & web.config
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
            }
            //   throw new ApplicationException(connectionString);
            Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}
