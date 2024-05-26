using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.ForgotPassword.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Login.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : Command<bool>
    {
        public ForgotPasswordCommand(ForgotPasswordInput input)
        {
            Input = input;
        }

        public ForgotPasswordInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new ForgotPasswordValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}