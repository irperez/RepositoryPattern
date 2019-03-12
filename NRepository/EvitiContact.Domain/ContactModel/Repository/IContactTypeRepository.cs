using EvitiContact.ApplicationService.RepositoryDB;
using EvitiContact.ContactModel;

namespace EvitiContact.Domain.ContactModel.Repository
{
    public interface IContactTypeRepository : IRepository<ContactType, int>
    {
        //IEnumerable<Contact> GetTopSellingCourses(int count);
        //IEnumerable<Contact> GetCoursesWithAuthors(int pageIndex, int pageSize);

        bool Exists(int ID);


        int MaxId();
    }


}
