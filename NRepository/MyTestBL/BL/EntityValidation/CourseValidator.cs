using System;
using FluentValidation;
using NRepository.UniversityBL.Domain;

namespace NRepository.UniversityBL.BL.EntityValidation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(p => p.Guid).NotEmpty();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Please specify a course name.")
                .MaximumLength(1024)
                .MinimumLength(4);

            RuleFor(p => p.StartDate)
                .GreaterThan(new DateTimeOffset(new DateTime(2018, 1, 1)));

            RuleFor(p => p.AverageRating)
                .InclusiveBetween(0, 5);
        }
    }
}
