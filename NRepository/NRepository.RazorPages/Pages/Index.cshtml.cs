using Microsoft.AspNetCore.Mvc.RazorPages;
using NRepository.UniversityBL.BL;
using System;

namespace NRepository.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(CourseProvider courseProvider)
        {
            CourseProvider = courseProvider;
        }

        public CourseProvider CourseProvider { get; set; }

        public void OnGet()
        {
            if(CourseProvider == null)
            {
                throw new ArgumentNullException("TestProvider");
            }
        }
    }
}
