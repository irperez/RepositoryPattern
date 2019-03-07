
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace WebHelper.RazorPlaybook
{
    /*
  Supporting Javascript

      function configure() {
  var base64String = $("#__pageModelConfig").val();

  var jsonString = atob(base64String);

  return JSON.parse(jsonString);
  }


      $(document).ready(function () {
  // <div class="video" onmouseenter="$(this).children('.detail').slideDown(750)" onmouseleave="$(this).children('.detail').slideUp(250)"

  $(".video").hover(function () {
      $(this).children('.detail').slideDown(750);
  },
      function () {
          $(this).children('.detail').slideUp(250)
      }
  );

  var pageData = configure();

  console.dir(pageData);

  listDebugData(pageData);
});

function listDebugData(model) {
  var debugObject = {
      FirstVideoTitle: model[0].Title,
      LastVideoTitle: model[model.length - 1].Title,
      VideoCount: model.length
  };

  console.dir(debugObject);

  var debugDiv = $("body").append("<div class='debug'></div>");
  $("div.debug").html(
      "<ul>\
              <li>First Video Title: " + debugObject.FirstVideoTitle + "</li >\
              <li>Last Video Title: " + debugObject.LastVideoTitle + "</li >\
              <li>Video Count: " + debugObject.VideoCount + "</li>\
          </ul>");
}


  */

    /// <summary>
    /// 
    /// used to serialize the values of a view model to a hidden input
    /// 
    /// From with in a form 
    /// @PageModelInjector.RenderContextAsInput(Html, Model)
    /// </summary>
    public static class PageModelInjector
    {
        public static HelperResult RenderContextAsInput(IHtmlHelper helper, object model)
        {
            return new HelperResult(async writer =>
            {
                writer.Write(
                    "<input type='hidden' id='__pageModelConfig' value='"
                    + System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model)))
                    + "' />");
            });
        }
    }

}
