using System;
using System.Linq;
using System.Threading.Tasks;
using EvitiContact.ContactModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace NRepository.RazorPages.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public EditModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact = await _context.Contact
                .Include(c => c.Type).FirstOrDefaultAsync(m => m.GUID == id);

            if (Contact == null)
            {
                return NotFound();
            }
            ViewData["TypeID"] = new SelectList(_context.ContactType, "ID", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Contact.GUID))
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

        private bool ContactExists(Guid id)
        {
            return _context.Contact.Any(e => e.GUID == id);
        }
    }
}
