using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(c => c.CourseName).MinimumLength(2);
            RuleFor(c => c.CourseName).NotEmpty();
            RuleFor(c => c.Price).GreaterThan(0);
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.Price).GreaterThanOrEqualTo(10).When(c => c.CategoryId == 1);
            RuleFor(c => c.CourseName).Must(StartWithA).WithMessage("Kurs isimleri A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
