using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvitiContact.ContactModel;

namespace NRepository.RazorPages.Pages.MD
{
    public class DetailsModel : PageModel
    {
        private readonly  ContactModelDbContext _context;

        public DetailsModel( ContactModelDbContext context)
        {
            _context = context;
        }

        public MDMaster MDMaster { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MDMaster = await _context.MDMaster.FirstOrDefaultAsync(m => m.MasterId == id);

            if (MDMaster == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
