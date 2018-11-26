using Microsoft.EntityFrameworkCore;
using NRepository.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRepository.UniversityBL.BL.DataAccess
{
    public class UniversityDbContextFactory : DesignTimeDbContextFactoryBase<UniversityContext>
    {
        protected override UniversityContext CreateNewInstance(DbContextOptions<UniversityContext> options)
        {
            return new UniversityContext(options);
        }
    }
}
