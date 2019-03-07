using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.CTViewModel
{
    public class DetailsModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public DetailsModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

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
    }
}
