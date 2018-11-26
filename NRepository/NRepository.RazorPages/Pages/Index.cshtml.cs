using Microsoft.AspNetCore.Mvc.RazorPages;
using NRepository.UniversityBL.BL;
using System;

namespace NRepository.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(CourseProvider testProvider)
        {
            TestProvider = testProvider;
        }

        public CourseProvider TestProvider { get; set; }

        public void OnGet()
        {
            if(TestProvider == null)
            {
                throw new ArgumentNullException("TestProvider");
            }
        }
    }
}
