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
    public class IndexModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public IndexModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

        public IList<ContactAddress> ContactAddress { get;set; }

        public async Task OnGetAsync()
        {
            ContactAddress = await _context.ContactAddress
                .Include(c => c.ContactGU)
                .Include(c => c.StateNavigation).ToListAsync();
        }
    }
}
