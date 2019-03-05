using System;
using System.Linq;
using EvitiContact.Domain.ContactModelDB;
using EvitiContact.Service;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NRepository.RazorPages.Pages.MD
{

    public class APIErrorLine
    {
        public string Name { get; set; }

        public string Message { get; set; }

    }


    /// <summary>
    /// Changed to allow for query string parameters or null
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[ValidateModel]
    public class MDController : ControllerBase
    {

        //private readonly ContactModelDbContext _context;
        //private readonly IMapper _mapper;
        private readonly bool IsFormatedArrayOn = true;

        private readonly MasterDetailControllerService _service;

        public MDController(MasterDetailControllerService service)
        {
            //_context = context;
            //_mapper = mapper;
            _service = service;
        }
        [HttpGet()]
        public ActionResult<MDMasterViewModel> Get([FromQuery(Name = "id")] Guid id)
        {
            if (id == Guid.Empty)
            {
                return _service.Get();

            }
            else
            {
                return _service.Get(id);
            }
        }
        // GET: api/<controller>
        //[HttpGet]
        //public ActionResult<MDMasterViewModel> Get()
        //{
        //    return _service.Get();
        //}


        //[HttpGet("{id}")]
        //public ActionResult<MDMasterViewModel> Get(   Guid id)
        //{
        //    return _service.Get(id);
        //}

        //[HttpGet("{customerId}", Name = "CustomerGet")]
        //public IActionResult Get(int id)
        //{
        //    return Ok("value");
        //    //return "value";
        //}

        public static APIErrorLine[] GetAPIErrorFromModelState(ModelStateDictionary modelState)
        {
            var errors = modelState
                      .Where(e => e.Value.Errors.Count > 0)
                      .Select(e => new APIErrorLine
                      {
                          Name = e.Key,
                          Message = e.Value.Errors.First().ErrorMessage
                      }).ToArray();

            return errors;
        }
        // POST api/<controller>
        [HttpPost]
        //  [ValidateAntiForgeryToken] //https://docs.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-2.1
        public ActionResult<MDMasterViewModel> Post([FromBody]MDMasterViewModel value)
        {

            var newModel = _service.Post(value);

            if (newModel.IsValid == false)
            {
                ValidationResult results = newModel.ValidationReult;
                results.AddToModelState(ModelState, null);
            }

            if (ModelState.IsValid == false)
            {
                // return BadRequest(ModelState.GetModelStateErrors());
                if (IsFormatedArrayOn)
                {
                    var APIError = GetAPIErrorFromModelState(ModelState);
                    return new ValidationFailedResult(ModelState);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            string url = Url.Link("CustomerGet", new { customerId = newModel.Payload.MasterId.ToString() });

            string t = url;
            return Accepted(url, newModel.Payload);

            //  string cookieToken = "";
            //  string formToken = "";

            //StringValues tokenHeaders;




            //  if (this.Request.Headers.TryGetValue("RequestVerificationToken", out tokenHeaders))
            //  {
            //      string[] tokens = tokenHeaders.First().Split(':');
            //      if (tokens.Length == 2)
            //      {
            //          cookieToken = tokens[0].Trim();
            //          formToken = tokens[1].Trim();
            //      }
            //  }
            //  AntiForgery.Validate(cookieToken, formToken);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
