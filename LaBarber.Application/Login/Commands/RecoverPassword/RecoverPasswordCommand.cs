using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.RecoverPassword.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Login.Commands.RecoverPassword
{
    public class RecoverPasswordCommand : Command<bool>
    {
        public RecoverPasswordCommand(RecoverPasswordInput input)
        {
            Input = input;
        }

        public RecoverPasswordInput Input { get; set;}

        public override bool IsValid()
        {
            ValidationResult = new RecoverPasswordValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}