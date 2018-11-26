using Microsoft.EntityFrameworkCore;
using NRepository.EF;
using NRepository.UniversityBL.Domain;
using NSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NRepository.UniversityBL.BL
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }

        public List<Guid> GetChildGuids(ASpec<Course> specification)
        {
            //NOTE: The lack of a using statement here
            return Context.Set<Course>()
                    .Include(h => h.Topics)
                    .Where(specification).ToList()
                    .SelectMany(t => t.Topics).ToList()
                    .Select(p => p.Guid).ToList();
        }
    }
}
