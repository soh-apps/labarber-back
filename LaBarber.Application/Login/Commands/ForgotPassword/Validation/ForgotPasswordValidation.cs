using FluentValidation;
using LaBarber.Application.Login.Boundaries;

namespace LaBarber.Application.Login.Commands.ForgotPassword.Validation
{
    public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordInput>
    {
        public ForgotPasswordValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("E-mail em formato inválido");
        }
    }
}