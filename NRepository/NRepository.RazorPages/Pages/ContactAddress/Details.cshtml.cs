using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.NewFolder
{
    public class DetailsModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public DetailsModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
