using FluentValidation;
using LaBarber.Application.Login.Boundaries;

namespace LaBarber.Application.Login.Commands.RecoverPassword.Validation
{
    public class RecoverPasswordValidation : AbstractValidator<RecoverPasswordInput>
    {
        public RecoverPasswordValidation()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .Length(6)
                .WithMessage("Codigo inválido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Senha é obrigatório");
        }
    }
}