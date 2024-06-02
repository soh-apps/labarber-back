using FluentValidation;
using LaBarber.Application.Login.Boundaries;

namespace LaBarber.Application.Login.Commands.RefreshToken.Validation
{
    public class RefreshTokenValidation : AbstractValidator<RefreshTokenInput>
    {
        public RefreshTokenValidation()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .WithMessage("RefreshToken é obrigatório");

            RuleFor(x => x.CredentialId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Id de credencial é obrigatório");
        }
    }
}