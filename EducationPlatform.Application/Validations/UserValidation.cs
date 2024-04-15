using EducationPlatform.Domain.Entity;
using FluentValidation;

namespace EducationPlatform.Application.Validations
{
    public class UserValidation : AbstractValidator<UserInput>
    {
        public UserValidation()
        {

            RuleFor(e => e.FullName)
                .NotEmpty().WithMessage("Nome completo não pode ser vazio")
                .MaximumLength(30).WithMessage("Nome muito longo");

            RuleFor(user => user.CPF)
                .NotEmpty()
                .Length(11)
                .WithMessage("O CPF é obrigatório e deve ter 11 caracteres.");

            RuleFor(user => user.Profile)
                .NotEmpty()
                .IsInEnum()
                .WithMessage("O perfil é obrigatório e deve ser válido.");

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("O e-mail é obrigatório e deve ser válido.");

            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("A senha é obrigatória e deve ter pelo menos 8 caracteres.");

            RuleFor(e => e.Birthday)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de início não pode ser menor que a data atual");
        }
    }
}
