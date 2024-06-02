using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.RefreshToken.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Login.Commands.RefreshToken
{
    public class RefreshTokenCommand : Command<LoginOutput>
    {
        public RefreshTokenCommand(RefreshTokenInput input)
        {
            Input = input;
        }
        public RefreshTokenInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new RefreshTokenValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}