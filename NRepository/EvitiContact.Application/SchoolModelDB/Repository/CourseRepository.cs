using EvitiContact.Domain.SchoolModel.Repository;
using EvitiContact.SchoolModel;
using EvitiContact.Service.RepositoryDB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EvitiContact.ApplicationService.SchoolModelDB.Repository
{

    public class CourseRepository : RepositoryGenericBase<Course, int>, ICourseRepository
    {
        public CourseRepository(SchoolModelDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return MyDBContext.Course.OrderByDescending(c => c.Department.Name).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return MyDBContext.Course
                .Include(c => c.Department)
                .OrderBy(c => c.Title)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public SchoolModelDbContext MyDBContext => Context as SchoolModelDbContext;
    }
}
