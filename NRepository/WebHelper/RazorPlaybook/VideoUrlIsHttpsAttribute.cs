using System.ComponentModel.DataAnnotations;

namespace WebHelper.RazorPlaybook
{
    //C:\PluralSite\ASP.NET Core 2 Razor Playbook - 27 Jun 2018\aspdotnet-core-2-razor-playbook\08\demos\RazorCorp.Web
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
    //    @model ErrorViewModel
    //@{
    //    ViewData["Title"] = "Error";
    //}

    //<h1 class="text-danger">Error.</h1>
    //<h2 class="text-danger">An error occurred while processing your request.</h2>

    //@if(Model.ShowRequestId)
    //{
    //    < p >
    //        < strong > Request ID:</ strong > < code > @Model.RequestId </ code >

    //       </ p >
    //}

    //<h3>Development Mode</h3>
    //<p>
    //    Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
    //</p>
    //<p>
    //    <strong>Development environment should not be enabled in deployed applications</strong>, as it can result in sensitive information from exceptions being displayed to end users.For local debugging, development environment can be enabled by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>, and restarting the application.
    //</p>

    public class VideoUrlIsHttpsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var videoUrl = value.ToString();

            return videoUrl.ToLower().StartsWith("https");
        }

        public override string FormatErrorMessage(string name)
        {
            return $"'{name}' is not a secure url.";
        }
    }

}
