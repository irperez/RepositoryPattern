using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvitiContact.ContactModel;
using AutoMapper;
using EvitiContact.Service.RepositoryDB;
using EvitiContact.Domain.ContactModelDB;
using eviti.Data.Tracking.BaseObjects;

namespace NRepository.RazorPages.Pages.CTViewModel
{
    public class DeleteModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContactAndShoool _unitOfWork;

        public DeleteModel(IMapper mapper, IUnitOfWorkContactAndShoool unitOfWork)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


             
            ContactType ct = new ContactType();
            ct.ID = id.Value;
            ct.TrackingState =  TrackingState.Deleted;
            _unitOfWork.ContactTypeRepository.AttachOnly(ct);

          //  ContactType = await _context.ContactType.FindAsync(id);

            //if (ContactType != null)
            //{
            //    _context.ContactType.Remove(ContactType);
            //    await _context.SaveChangesAsync();
            //}

            _unitOfWork.Commit();

            return RedirectToPage("./Index");
        }
    }
}
