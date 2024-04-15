using EducationPlatform.Domain.Entity;
using FluentValidation;

namespace EducationPlatform.Application.Validations
{
    public class BlockValidation : AbstractValidator<BlockInput>
    {
        public BlockValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio");

            RuleFor(e => e.Description)
                .MaximumLength(200);

            RuleFor(e => e.CreationDate).GreaterThanOrEqualTo(DateTime.Now)
                            .WithMessage("A data de início não pode ser menor que a data atual");

            RuleFor(e => e.IdCourse)
                .NotEmpty().WithMessage("IdCourse não pode ser vazio")
                .NotEqual(0).WithMessage("IdCourse não pode ser igual a 0");
        }
    }
}
