using EvitiContact.ContactModel;
using EvitiContact.Service.RepositoryDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvitiContact.ApplicationService.ContactModelDB.Repository
{

    public class ContactReposatory : RepositoryGenericBase<Contact, Guid>, IContactRepository
    {
        public ContactReposatory(ContactModelDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Contact> GetTopSellingCourses(int count)
        {
            return MyDBContext.Contact.OrderByDescending(c => c.CreatedDate).Take(count).ToList();
        }

        public IEnumerable<Contact> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return MyDBContext.Contact
                .Include(c => c.ContactAddresses)
                .OrderBy(c => c.CreatedDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public ContactModelDbContext MyDBContext => Context as ContactModelDbContext;
    }




}
