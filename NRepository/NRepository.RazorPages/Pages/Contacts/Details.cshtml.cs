using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public DetailsModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
