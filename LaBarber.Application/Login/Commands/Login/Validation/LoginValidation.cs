using FluentValidation;
using LaBarber.Application.Login.Boundaries;

namespace LaBarber.Application.Login.Commands.Login.Validation
{
    public class LoginValidation : AbstractValidator<LoginInput>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Nome de usuário obrigatório.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("A senha é obrigatória.");
        }
    }
}
