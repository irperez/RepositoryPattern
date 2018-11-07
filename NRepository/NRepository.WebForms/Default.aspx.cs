using NRepository.MyTestBL.BL;
using System;
using System.ComponentModel.Composition;
using System.Web.UI;

namespace NRepository.WebForms
{
    public partial class _Default : Page
    {
        [Import]
        public TestProvider TestProvider { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(TestProvider == null)
            {
                throw new ArgumentNullException("TestProvider");
            }
        }
    }
}