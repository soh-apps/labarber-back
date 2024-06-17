using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Barber.Commands
{
    public class CreateBarberCommand : Command<bool>
    {
        public CreateBarberInput Input { get; set; }
        public CreateBarberCommand(CreateBarberInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateBarberValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
