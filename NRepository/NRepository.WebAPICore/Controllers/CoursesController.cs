using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NRepository.UniversityBL.BL;
using NRepository.UniversityBL.BL.EntityValidation;
using NRepository.UniversityBL.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NRepository.WebAPICore.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        public CourseProvider CourseProvider { get; set; }
        protected CourseValidator CourseValidator { get; set; }

        public CoursesController(CourseProvider courseProvider)
        {
            CourseProvider = courseProvider;
            CourseValidator = new CourseValidator();
        }

        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult Get()
        {
            return Ok(CourseProvider.GetAllCourses());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Course))]
        [ProducesResponseType(404)]
        public IActionResult Get(Guid id)
        {
            var result =  CourseProvider.Get(id);

            if(result == null)
            {
                return NotFound(id);
            }

            return Ok(result);
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400, Type = typeof(ValidationResult))]
        public IActionResult Post([FromBody]Course value)
        {            
            var result = CourseProvider.Add(value);

            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            else
            {
                return CreatedAtAction("POST: api/Courses/", value);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id:Guid}")]
        public void Put(Guid id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id:Guid}")]
        public void Delete(Guid id)
        {
            
        }
    }
}
