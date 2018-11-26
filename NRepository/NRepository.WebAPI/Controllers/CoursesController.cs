using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NRepository.UniversityBL.BL;
using NRepository.UniversityBL.Domain;

namespace NRepository.WebAPI.Controllers
{
    public class CoursesController : ApiController
    {
        public CourseProvider CourseProvider { get; set; }

        public CoursesController(CourseProvider courseProvider)
        {
            CourseProvider = courseProvider;
        }

        // GET api/<controller>
        public IEnumerable<Course> Get()
        {
            return CourseProvider.GetAllCourses();
        }

        // GET api/<controller>/5
        public Course Get(Guid id)
        {
            return CourseProvider.Get(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
