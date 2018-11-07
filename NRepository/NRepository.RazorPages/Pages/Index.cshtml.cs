using Microsoft.AspNetCore.Mvc.RazorPages;
using NRepository.MyTestBL.BL;
using System;

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
