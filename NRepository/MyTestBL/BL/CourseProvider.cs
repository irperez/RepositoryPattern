using FluentValidation.Results;
using NRepository.UniversityBL.BL.EntityValidation;
using NRepository.UniversityBL.Domain;
using System;
using System.Collections.Generic;

namespace NRepository.UniversityBL.BL
{
    //NSpecifications nuget package can be found here: https://www.nuget.org/packages/NSpecifications
    //Github: https://github.com/jnicolau/NSpecifications
    //Unit of Work/Repository Concepts: https://medium.com/@utterbbq/c-unitofwork-and-repository-pattern-305cd8ecfa7a
    public class CourseProvider
    {
        public ICourseRepository CourseRepository { get; set; }
        protected CourseValidator CourseValidator { get; set; }

        public CourseProvider(ICourseRepository repository) //Do not create another constructor
        {
            CourseRepository = repository;
            CourseValidator = new CourseValidator();
        }

        public List<Course> GetAllCourses()
        {
            return CourseRepository.Get();
        }

        public Course Get(Guid id)
        {
            return CourseRepository.GetSingle(CourseSpecs.ById(id));
        }

        public List<Guid> GetSubjectGuids()
        {
            return CourseRepository.GetChildGuids(CourseSpecs.HighRatingSpec(5));
        }

        public List<Course> GetHighlyRatedCourses()
        {
            return CourseRepository.Get(CourseSpecs.HighRatingSpec(4));
        }

        public List<Course> GetHistoricalCourses(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return CourseRepository.Get(CourseSpecs.TimeFrame(startDate, endDate));
        }

        public List<Course> GetHighRatedHistoricalCourses(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            //Here we are combining preexisting specs using "AND" logic.
            return CourseRepository.Get(CourseSpecs.TimeFrame(startDate, endDate) & CourseSpecs.HighRatingSpec(4));
        }

        public ValidationResult Add(Course instance)
        {
            var validationResult = CourseValidator.Validate(instance);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            else
            {
                CourseRepository.Add(instance);
                return null;
            }
        }

        public ValidationResult Update(Course instance)
        {
            var validationResult = CourseValidator.Validate(instance);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }
            else
            {
                CourseRepository.Save(instance);
                return null;
            }
        }
    }
}
