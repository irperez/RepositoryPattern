using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModel.Repository;
using EvitiContact.Service.RepositoryDB;
using System;
using System.Linq;

namespace EvitiContact.ApplicationService.ContactModelDB.Repository
{
    public class ContactTypeReposatory : RepositoryGenericBase<ContactType, int>, IContactTypeRepository
    {
        public ContactTypeReposatory(ContactModelDbContext context)
            : base(context)
        {
        }
         
        public ContactModelDbContext MyDBContext => Context as ContactModelDbContext;

        public bool Exists(int id)
        {
             return MyDBContext.ContactType.Any(e => e.ID == id);
        }

        public int MaxId()
        {
            var max = MyDBContext.ContactType.OrderByDescending(x => x.ID).FirstOrDefault();
            if (max!=null)
            { return max.ID; }
            else
            { return 0; }
       
        }
    }


}
