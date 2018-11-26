using NRepository.UniversityBL.BL;
using System;
using System.ComponentModel.Composition;
using System.Web.UI;

namespace NRepository.WebForms
{
    public partial class _Default : Page
    {
        [Import]
        public CourseProvider CourseProvider { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(CourseProvider == null)
            {
                throw new ArgumentNullException("CourseProvider");
            }
        }
    }
}
