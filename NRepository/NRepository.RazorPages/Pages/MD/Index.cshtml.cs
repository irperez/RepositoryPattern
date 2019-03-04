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
    public class IndexModel : PageModel
    {
        private readonly  ContactModelDbContext _context;

        public IndexModel( ContactModelDbContext context)
        {
            _context = context;
        }

        public IList<MDMaster> MDMaster { get;set; }

        public async Task OnGetAsync()
        {
            MDMaster = await _context.MDMaster.ToListAsync();
        }
    }
}
