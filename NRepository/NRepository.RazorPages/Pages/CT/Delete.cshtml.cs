using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.CT
{
    public class DeleteModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public DeleteModel(EvitiContact.ContactModel.ContactModelDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactType = await _context.ContactType.FindAsync(id);

            if (ContactType != null)
            {
                _context.ContactType.Remove(ContactType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
