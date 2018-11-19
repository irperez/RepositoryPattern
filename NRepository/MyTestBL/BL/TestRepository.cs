using Microsoft.EntityFrameworkCore;
using NRepository.EF;
using NRepository.MyTestBL.Domain;
using NSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NRepository.MyTestBL.BL
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        public TestRepository(DbContext context) : base(context)
        {
        }

        public List<Guid> GetChildGuids(ASpec<Test> specification)
        {
            //NOTE: The lack of a using statement here
            return Context.Set<Test>()
                    .Include(h => h.TestItems)
                    .Where(specification).ToList()
                    .SelectMany(t => t.TestItems).ToList()
                    .Select(p => p.Guid).ToList();
        }
    }
}
