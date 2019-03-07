using System.IO;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebHelper.RazorPlaybook
{


    // used to set the values of a image height and width. 
    public class ImgTagHelper : TagHelper
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        public ImgTagHelper(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            hostingEnvironment = env;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var imagePath = context.AllAttributes["src"].Value.ToString();

            var filePath = Path.Combine(hostingEnvironment.WebRootPath, imagePath.Split('/')[1] + "\\" + imagePath.Split('/')[2] + "\\" + imagePath.Split('/')[3]);

            //using (var image = new Bitmap(filePath))
            //{
            //    output.Attributes.SetAttribute("width", (image.Width / 25));
            //    output.Attributes.SetAttribute("height", (image.Height / 25));
            //}
        }
    }

}
