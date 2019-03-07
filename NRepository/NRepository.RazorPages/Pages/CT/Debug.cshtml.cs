using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace NRepository.RazorPages.Pages.CT
{
    public class DebugModel : PageModel
    {

        private readonly ContactModelDbContext _context;
        private readonly AutoMapper.IMapper _mapper;

        public DebugModel(ContactModelDbContext context, AutoMapper.IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task OnGet()
        {
            ContactTypes = _mapper.Map<IList<ContactType>, IList<ContactTypeViewModel>>(await _context.ContactType.ToListAsync());
            MDMasters = _mapper.Map<IList<MDMaster>, IList<MDMasterViewModel>>(await _context.MDMaster.ToListAsync());

        }

        public IList<ContactTypeViewModel> ContactTypes { get; set; }

        public IList<MDMasterViewModel> MDMasters { get; set; }


        public Microsoft.AspNetCore.Mvc.JsonResult OnGetLatest()
        {
            return new Microsoft.AspNetCore.Mvc.JsonResult(_context.ContactType.OrderByDescending(x => x.Name).First());
        }
    }
}
