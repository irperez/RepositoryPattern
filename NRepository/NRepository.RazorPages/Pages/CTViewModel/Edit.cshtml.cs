using System.Threading.Tasks;
using AutoMapper;
using eviti.Data.Tracking.BaseObjects;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NRepository.RazorPages.Infrastructure;

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
            ContactType ct;
            if (id.HasValue)
            {
                ct = _unitOfWork.ContactTypeRepository.Get(id.Value);
            }
            else
            {
                ct = new ContactType();
                // Restaurant = new Restaurant();
            }
            if (ct == null)
            {
                return NotFound(); // return RedirectToPage("./NotFound");
            }


            //if (id == null)
            //{
            //    return NotFound();
            //}

            //ContactType = await _context.ContactType.FirstOrDefaultAsync(m => m.ID == id);


            //if (ct == null)
            //{
            //    return NotFound();
            //}
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


            if (ct.ID == 0)
            {
                // this is needed ONLY because we are setting the primary key here.
                ct.TrackingState = TrackingState.Added;

                ct.ID = _unitOfWork.ContactTypeRepository.MaxId() + 1;
            }
            else
            {
                // edit - this should just work. 
            }
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
            TempData["Message"] = "Contact Type saved!";
            return this.RedirectToPageJson("Index");
        //    return this.RedirectToPageJson(nameof(IndexModel));
          //  return RedirectToPage("./Index");
        }

        private bool ContactTypeExists(int id)
        {
            return _unitOfWork.ContactTypeRepository.Exists(id);
            //  return _context.ContactType.Any(e => e.ID == id);
        }
    }
}
