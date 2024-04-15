using EducationPlatform.Domain.Entity;
using FluentValidation;

namespace EducationPlatform.Application.Validations
{
    public class SignatureValidation : AbstractValidator<SignatureInput>
    {
        public SignatureValidation()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Nome vazio")
                .MaximumLength(100).WithMessage("Nome muito deve ter menos de 100 caracteres")
                .MinimumLength(2).WithMessage("Nome muito deve ter mais de 2 caracteres");

            RuleFor(e => e.Name)
                .MaximumLength(9999);
        }
    }
}
