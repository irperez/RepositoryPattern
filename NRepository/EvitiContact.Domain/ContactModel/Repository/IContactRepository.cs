using EvitiContact.ApplicationService.RepositoryDB;
using EvitiContact.ContactModel;
using System;
using System.Collections.Generic;

namespace EvitiContact.Domain.ContactModel.Repository
{
    public interface IContactRepository : IRepository<Contact, Guid>
    {
        IEnumerable<Contact> GetTopSellingCourses(int count);
        IEnumerable<Contact> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
     
}
