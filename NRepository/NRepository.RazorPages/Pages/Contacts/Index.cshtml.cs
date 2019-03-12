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
    public class IndexModel : PageModel
    {
        private readonly EvitiContact.ContactModel.ContactModelDbContext _context;

        public IndexModel(EvitiContact.ContactModel.ContactModelDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; }

        public async Task OnGetAsync()
        {
            Contact = await _context.Contact
                .Include(c => c.Type).ToListAsync();
        }
    }
}
