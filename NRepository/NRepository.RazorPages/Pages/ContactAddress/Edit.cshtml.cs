using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.NewFolder
{
    public class EditModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public EditModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactAddress ContactAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactAddress = await _context.ContactAddress
                .Include(c => c.ContactGU)
                .Include(c => c.StateNavigation).FirstOrDefaultAsync(m => m.GUID == id);

            if (ContactAddress == null)
            {
                return NotFound();
            }
           ViewData["ContactGUID"] = new SelectList(_context.Contact, "GUID", "CreatedBy");
           ViewData["State"] = new SelectList(_context.States, "StateCode", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContactAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactAddressExists(ContactAddress.GUID))
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

        private bool ContactAddressExists(Guid id)
        {
            return _context.ContactAddress.Any(e => e.GUID == id);
        }
    }
}
