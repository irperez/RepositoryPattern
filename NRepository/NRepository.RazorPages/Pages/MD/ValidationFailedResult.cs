using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace NRepository.RazorPages.Pages.MD
{
    //https://www.jerriepelser.com/blog/validation-response-aspnet-core-webapi/
    //https://www.strathweb.com/2018/02/exploring-the-apicontrollerattribute-and-its-features-for-asp-net-core-mvc-2-1/
    //https://github.com/aspnet/AspNetCore/blob/master/src/Mvc/src/Microsoft.AspNetCore.Mvc.Core/BadRequestObjectResult.cs
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new ValidationResultModel(modelState))
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }


    // use this on the control to validate with this attribuge [ValidateModel]
    //[Authorize]
    //[Route("api/properties")]
    //[ValidateModel]
    //public class PropertiesController : Controller
    //{
    //    // code omitted for brevity
    //}
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }


    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Name = field != string.Empty ? field : null;
            Message = message;
        }
    }

    public class ValidationResultModel
    {
        public string Message { get; }

        public List<ValidationError> Errors { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            Errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
