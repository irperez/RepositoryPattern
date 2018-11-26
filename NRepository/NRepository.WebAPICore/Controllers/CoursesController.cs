using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NRepository.UniversityBL.BL;
using NRepository.UniversityBL.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NRepository.WebAPICore.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        public CourseProvider CourseProvider { get; set; }

        public CoursesController(CourseProvider courseProvider)
        {
            CourseProvider = courseProvider;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Course> Get()
        {
            return CourseProvider.GetAllCourses();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Course Get(Guid id)
        {
            return CourseProvider.Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ValidationResult Post([FromBody]Course value)
        {
            return CourseProvider.Add(value);
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
