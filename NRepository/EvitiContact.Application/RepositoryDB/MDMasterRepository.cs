using AutoMapper;
using AutoMapper.QueryableExtensions;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EvitiContact.Service.RepositoryDB
{


    public class MDMasterRepository : Repository<MDMaster, Guid>, IMDMasterRepository
    {

        private readonly IMapper _mapper;

        public MDMasterRepository(ContactModelDbContext context, IMapper mapper)
            : base(context)
        {
             _mapper = mapper;
        }

        public IEnumerable<MDMaster> GetTopMDMasterByCreatedDate(int count)
        {
            return MyDBContext.MDMaster.OrderByDescending(c => c.CreatedDate).Take(count).ToList();
        }


        public MDMasterViewModel GetVM(Guid id)
        {
            //-- See https://docs.microsoft.com/en-us/ef/core/querying/related-data and https://stackoverflow.com/questions/45264534/automapper-projectto-ignoring-include
            MDMasterViewModel viewModel = MyDBContext.MDMaster
                       .Where(x => x.MasterId == id)
                       // this will trigger an include (of MDDetails) automatically 
                       //because of the mapping profile that has the mddetails in it already   
                       .ProjectTo<MDMasterViewModel>(_mapper.ConfigurationProvider)
                       .FirstOrDefault();

            return viewModel;
        }
        public IEnumerable<MDMaster> GetMasterWithDetails(int pageIndex, int pageSize = 10)
        {
            return MyDBContext.MDMaster
                .Include(c => c.MDDetails)
                .OrderBy(c => c.CreatedDate)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public ContactModelDbContext MyDBContext => Context as ContactModelDbContext;
    }


    public interface IMDMasterRepository : IRepository<MDMaster, Guid>
    {
        IEnumerable<MDMaster> GetTopMDMasterByCreatedDate(int count);
        IEnumerable<MDMaster> GetMasterWithDetails(int pageIndex, int pageSize);
        MDMasterViewModel GetVM(Guid id);
    }
}
