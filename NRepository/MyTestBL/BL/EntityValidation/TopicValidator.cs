using FluentValidation;
using NRepository.UniversityBL.Domain;

namespace NRepository.UniversityBL.BL.EntityValidation
{
    public class TopicValidator : AbstractValidator<Topic>
    {
        public TopicValidator()
        {
            RuleFor(p => p.CourseId).NotEmpty();

            RuleFor(p => p.Description)
                .MaximumLength(1024);

            RuleFor(p => p.Subject)
                .NotEmpty()
                .MaximumLength(1024)
                .MinimumLength(10);

            RuleFor(p => p.Guid).NotEmpty();
        }
    }
}
