using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.CT
{
    public class CreateModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public CreateModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactType ContactType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ContactType.Add(ContactType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}