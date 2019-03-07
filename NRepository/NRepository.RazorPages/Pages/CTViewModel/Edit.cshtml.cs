using System.Threading.Tasks;
using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace NRepository.RazorPages.Pages.CTViewModel
{
    public class EditModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContactAndShoool _unitOfWork;

        public EditModel(IMapper mapper, IUnitOfWorkContactAndShoool unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }



        [BindProperty]
        public ContactTypeViewModel ContactType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             
            //ContactType = await _context.ContactType.FirstOrDefaultAsync(m => m.ID == id);
            var ct = _unitOfWork.ContactTypeRepository.Get(id.Value);

            if (ct == null)
            {
                return NotFound();
            }
            ContactType = _mapper.Map<ContactTypeViewModel>(ct);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ContactType ct = _mapper.Map<ContactType>(ContactType);

            _unitOfWork.ContactTypeRepository.AttachOnly(ct);

            //  _context.Attach(ContactType).State = EntityState.Modified;

            try
            {
                _unitOfWork.Commit();
                //  await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactTypeExists(ContactType.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactTypeExists(int id)
        {
            return _unitOfWork.ContactTypeRepository.Exists(id);
            //  return _context.ContactType.Any(e => e.ID == id);
        }
    }
}
