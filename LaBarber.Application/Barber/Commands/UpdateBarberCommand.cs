using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Barber.Commands
{
    public class UpdateBarberCommand(UpdateBarberInput input) : Command<bool>
    {
        public UpdateBarberInput Input { get; set; } = input;

        public override bool IsValid()
        {
            ValidationResult = new UpdateBarberValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
