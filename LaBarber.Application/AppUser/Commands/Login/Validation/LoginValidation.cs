using FluentValidation;
using LaBarber.Application.AppUser.Boundaries;

namespace LaBarber.Application.AppUser.Commands.Login.Validation
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
