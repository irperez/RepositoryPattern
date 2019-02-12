using Microsoft.EntityFrameworkCore;
using NRepository.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace University.Data
{
    public class UniversityDbContextFactory : DesignTimeDbContextFactoryBase<UniversityContext>
    {
        private string _myConnectionStringName = "UniversityDB";

        // Override auto-implemented property with ordinary property
        // to provide specialized accessor behavior.
        protected override string ConnectionStringName
        {
            get
            {
                return _myConnectionStringName;
            }
            set
            {
                 
                    _myConnectionStringName = value;
                
            }
        }
        protected override UniversityContext CreateNewInstance(DbContextOptions<UniversityContext> options)
        {
            return new UniversityContext(options);
        }
    }
}
