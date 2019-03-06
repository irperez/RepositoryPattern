using EvitiContact.ApplicationService.RepositoryDB;
using EvitiContact.SchoolModel;
using System.Collections.Generic;

namespace EvitiContact.ApplicationService.SchoolModelDB.Repository
{
    public interface ICourseRepository : IRepository<Course, int>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}
