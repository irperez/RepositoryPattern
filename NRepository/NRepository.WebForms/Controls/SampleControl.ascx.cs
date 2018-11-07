using NRepository.MyTestBL.BL;
using System;
using System.ComponentModel.Composition;

namespace NRepository.WebForms.Controls
{
    public partial class SampleControl : System.Web.UI.UserControl
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