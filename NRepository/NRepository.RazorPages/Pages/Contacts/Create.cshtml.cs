using System.Threading.Tasks;
using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NRepository.RazorPages.Pages.Contacts
{
    public class CreateModel : PageModel
    {

        // private readonly EvitiContact.ContactModel.ContactModelDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContactAndShoool _unitOfWork;
        public CreateModel(IMapper mapper, IUnitOfWorkContactAndShoool unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnGet()
        {

            var ctList = _unitOfWork.ContactTypeRepository.GetAll();
            ViewData["TypeID"] = new SelectList(ctList, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public ContactViewModel Contact { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Contact contact = _mapper.Map<Contact>(Contact);
            _unitOfWork.Contacts.AttachOnly(contact);
            _unitOfWork.Commit();
            //_context.Contact.Add(Contact);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
