using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EvitiContact.ContactModel;



namespace NRepository.RazorPages.Pages.MD
{
    public class CreateModel : PageModel
    {
        private readonly  ContactModelDbContext _context;

        public CreateModel( ContactModelDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MDMaster MDMaster { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MDMaster.Add(MDMaster);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
