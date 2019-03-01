using EvitiContact.SchoolModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EvitiContact.Service.RepositoryDB
{

    public interface ICourseRepository : IRepository<Course, int>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }

    public class CourseRepository : Repository<Course, int>, ICourseRepository
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
