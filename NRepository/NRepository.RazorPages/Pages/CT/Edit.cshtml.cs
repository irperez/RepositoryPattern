using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.CT
{
    public class EditModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public EditModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactType ContactType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactType = await _context.ContactType.FirstOrDefaultAsync(m => m.ID == id);

            if (ContactType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContactType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            return _context.ContactType.Any(e => e.ID == id);
        }
    }
}
