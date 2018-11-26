using NRepository.UniversityBL.Domain;
using NSpecifications;
using System;

namespace NRepository.UniversityBL.BL
{
    public static class CourseSpecs
    {
        //Let's define our specs in the provider
        public static Spec<Course> HighRatingSpec(int averageRating)
        {
            return new Spec<Course>(t => t.AverageRating >= averageRating);
        }

        public static Spec<Course> TimeFrame(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return new Spec<Course>(t => t.StartDate >= startDate && t.StartDate <= endDate);
        }

        public static Spec<Course> ById(Guid guid)
        {
            return new Spec<Course>(t => t.Guid == guid);
        }
    }
}
