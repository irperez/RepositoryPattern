using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace NRepository.RazorPages.Pages.Contacts
{
    public class Index : PageModel
    {
        // private readonly EvitiContact.ContactModel.ContactModelDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContactAndShoool _unitOfWork;
        private readonly ILogger<Index> _logger;

        public Index(IMapper mapper, IUnitOfWorkContactAndShoool unitOfWork, ILogger<Index> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IList<ContactViewModel> Contact { get; set; }


        [TempData]
        public string Message { get; set; }


        public async Task OnGetAsync()
        {
            _logger.LogInformation("Contact List Pre Select");
            IEnumerable<Contact> allitems = _unitOfWork.Contacts.GetAllWithContactType();
            _logger.LogInformation("Contact List Post Select");
            //var temp = await _context.Contact
            //      .Include(c => c.Type).ToListAsync();

            // var VMstores = Mapper.Map<IEnumerable<Store>, IEnumerable<StoreVM>>(stores);
            Contact = _mapper.Map<IEnumerable<Contact>, IList<ContactViewModel>>(allitems);
            // Contact = _mapper.Map<IList<Contact>>(allitems);
        }
    }
}
