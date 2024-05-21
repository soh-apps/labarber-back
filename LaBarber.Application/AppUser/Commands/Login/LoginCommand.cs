using LaBarber.Application.AppUser.Boundaries;
using LaBarber.Application.AppUser.Commands.Login.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.AppUser.Commands.Login
{
    public class LoginCommand : Command<bool>
    {
        public LoginCommand(LoginInput input) 
        {
            Input = input;
        }
        public LoginInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new LoginValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
