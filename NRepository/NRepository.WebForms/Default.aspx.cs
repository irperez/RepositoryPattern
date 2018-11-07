using NRepository.MyTestBL.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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