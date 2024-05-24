using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.Login.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Login.Commands.Login
{
    public class LoginCommand : Command<LoginOutput>
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
