using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace NRepository.RazorPages.Infrastructure
{
    public static class PageModelExtensions
    {
        public static ActionResult RedirectToPageJson<TPage>(this TPage controller, string pageName)
            where TPage : PageModel
        {
            //return controller.JsonNet(new
            //{
            //    redirect = controller.Url.Page(pageName)
            //}
            //);


            var result = controller.JsonNet(new
            {
                redirect = controller.Url.Page(pageName)
            }
            );


            return result;
        }

        public static ContentResult JsonNet(this PageModel controller, object model)
        {
            var serialized = JsonConvert.SerializeObject(model, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return new ContentResult
            {
                Content = serialized,
                ContentType = "application/json"
            };
        }

    }
}
