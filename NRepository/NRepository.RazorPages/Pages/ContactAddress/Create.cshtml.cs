using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.NewFolder
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
        ViewData["ContactGUID"] = new SelectList(_context.Contact, "GUID", "CreatedBy");
        ViewData["State"] = new SelectList(_context.States, "StateCode", "Name");
            return Page();
        }

        [BindProperty]
        public ContactAddress ContactAddress { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ContactAddress.Add(ContactAddress);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}