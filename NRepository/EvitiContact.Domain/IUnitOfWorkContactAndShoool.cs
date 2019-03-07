

using EvitiContact.Domain.ContactModel.Repository;
using EvitiContact.Domain.SchoolModel.Repository;

namespace EvitiContact.Service.RepositoryDB
{
    public interface IUnitOfWorkContactAndShoool : IUnitOfWorkBase
    {
        ICourseRepository Courses { get; }
        IContactRepository Contacts { get; }
        IMDMasterRepository MDDetails { get; }
        IContactTypeRepository ContactTypeRepository { get; }
    }
}
