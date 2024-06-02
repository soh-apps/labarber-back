using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.BarberUnit.Commands
{
    public class CreateBarberUnitCommand : Command<bool>
    {
        public CreateBarberUnitInput Input { get; set; }
        public CreateBarberUnitCommand(CreateBarberUnitInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateBarberUnitValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
