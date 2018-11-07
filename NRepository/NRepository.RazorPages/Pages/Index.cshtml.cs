using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NRepository.MyTestBL.BL;

namespace NRepository.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(TestProvider testProvider)
        {
            TestProvider = testProvider;
        }

        public TestProvider TestProvider { get; set; }

        public void OnGet()
        {
            if(TestProvider == null)
            {
                throw new ArgumentNullException("TestProvider");
            }
        }
    }
}
