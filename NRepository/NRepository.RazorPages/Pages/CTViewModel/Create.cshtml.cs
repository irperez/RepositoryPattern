using System.Threading.Tasks;
using eviti.Data.Tracking.BaseObjects;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NRepository.RazorPages.Pages.CTViewModel
{
    public class CreateModel : PageModel
    {
      //  private readonly ContactModelDbContext _context;

        private readonly AutoMapper.IMapper _mapper;
        private readonly IUnitOfWorkContactAndShoool _unitOfWork;

        public CreateModel(
            //ContactModelDbContext context, 
            AutoMapper.IMapper mapper, IUnitOfWorkContactAndShoool unitOfWork)
        {
       //     _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }




        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactTypeViewModel ContactType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ContactType ct = _mapper.Map<ContactType>(ContactType);

            // this is needed because we are setting the primary key here. 
             ct.TrackingState =  TrackingState.Added;
            _unitOfWork.ContactTypeRepository.AttachOnly(ct);
         
            _unitOfWork.Commit();
            //_context.ContactType.Add(ct);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
