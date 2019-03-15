using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NRepository.RazorPages.Pages.Contacts
{
    public class Index : PageModel
    {
        // private readonly EvitiContact.ContactModel.ContactModelDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContactAndShoool _unitOfWork;
        public Index(IMapper mapper, IUnitOfWorkContactAndShoool unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IList<ContactViewModel> Contact { get; set; }


        [TempData]
        public string Message { get; set; }


        public async Task OnGetAsync()
        {
            IEnumerable<Contact> allitems = _unitOfWork.Contacts.GetAllWithContactType();
            //var temp = await _context.Contact
            //      .Include(c => c.Type).ToListAsync();

            // var VMstores = Mapper.Map<IEnumerable<Store>, IEnumerable<StoreVM>>(stores);
            Contact = _mapper.Map<IEnumerable<Contact>, IList<ContactViewModel>>(allitems);
            // Contact = _mapper.Map<IList<Contact>>(allitems);
        }
    }
}
