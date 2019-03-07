using EvitiContact.ApplicationService.RepositoryDB;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using System;
using System.Collections.Generic;

namespace EvitiContact.Domain.ContactModel.Repository
{
    public interface IMDMasterRepository : IRepository<MDMaster, Guid>
    {
        IEnumerable<MDMaster> GetTopMDMasterByCreatedDate(int count);
        IEnumerable<MDMaster> GetMasterWithDetails(int pageIndex, int pageSize);
        MDMasterViewModel GetVM(Guid id);
    }


 
}
