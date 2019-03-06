using EvitiContact.ApplicationService.ContactModelDB.Repository;
using EvitiContact.ApplicationService.SchoolModelDB.Repository;

namespace EvitiContact.Service.RepositoryDB
{
    public interface IUnitOfWorkContactAndShoool : IUnitOfWorkBase
    {
        ICourseRepository Courses { get; }
        IContactRepository Contacts { get; }
        IMDMasterRepository MDDetails { get; }
    }
}
