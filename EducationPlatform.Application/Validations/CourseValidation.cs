using EducationPlatform.Domain.Entity;
using FluentValidation;

namespace EducationPlatform.Application.Validations
{
    public class CourseValidation : AbstractValidator<CourseInput>
    {
        public CourseValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Nome vazio")
                .MaximumLength(100).WithMessage("Nome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Nome muito deve ter mais de 2 caracteres");

            RuleFor(e => e.Description)
                .MaximumLength(200);

            RuleFor(e => e.CreationDate).GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de início não pode ser menor que a data atual");
        }
    }
}
