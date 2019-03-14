using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service.RepositoryDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NRepository.RazorPages.Infrastructure;

namespace NRepository.RazorPages.Pages.Contacts
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
        public ContactViewModel Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           var c =  _unitOfWork.Contacts.GetContactWithDetails(id.Value);
            Contact = _mapper.Map<ContactViewModel>(c);
            //Contact = await _context.Contact
            //    .Include(c => c.Type).FirstOrDefaultAsync(m => m.GUID == id);

            if (Contact == null)
            {
                return NotFound();
            }
            var ctList = _unitOfWork.ContactTypeRepository.GetAll();
            ViewData["TypeID"] = new SelectList(ctList, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
     
          //  _context.Attach(Contact).State = EntityState.Modified;

            //try
            //{
                Contact contact = _mapper.Map<Contact>(Contact);
            _unitOfWork.Contacts.AttachOnly(contact);
                _unitOfWork.Commit();
            //  await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ContactExists(Contact.GUID))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

           // return  this. RedirectToActionJson(nameof(Index));
            return this.RedirectToPageJson( "Index" );
          //  return RedirectToPage("./Index");
        }

        //private bool ContactExists(Guid id)
        //{
        //    return _context.Contact.Any(e => e.GUID == id);
        //}
    }
}
