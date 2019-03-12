using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EvitiContact.ContactModel;
using EvitiContact.Domain.ContactModelDB;

namespace NRepository.RazorPages.Pages.Contacts
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
            ViewData["TypeID"] = new SelectList(_context.ContactType, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public ContactViewModel Contact { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

          //  _context.Contact.Add(Contact);
           // await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
