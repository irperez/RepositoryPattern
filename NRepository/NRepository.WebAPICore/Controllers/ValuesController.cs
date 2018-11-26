using Microsoft.AspNetCore.Mvc;
using NRepository.UniversityBL.BL;
using System;
using System.Collections.Generic;

namespace NRepository.WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public CourseProvider CourseProvider { get; set; }

        public ValuesController(CourseProvider courseProvider)
        {
            CourseProvider = courseProvider;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            if(CourseProvider == null)
            {
                throw new ArgumentNullException("CourseProvider");
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
