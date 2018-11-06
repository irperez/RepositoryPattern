using Microsoft.EntityFrameworkCore;
using NRepository.Persistence.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace NRepository.MyTestBL.BL.DataAccess
{
    public class MyTestDbContextFactory : DesignTimeDbContextFactoryBase<MyTestContext>
    {
        protected override MyTestContext CreateNewInstance(DbContextOptions<MyTestContext> options)
        {
            return new MyTestContext(options);
        }
    }
}
