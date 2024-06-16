using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.BarberUnit.Commands
{
    public class UpdateBarberUnitCommand : Command<bool>
    {
        public UpdateBarberUnitInput Input { get; set; }
        public UpdateBarberUnitCommand(UpdateBarberUnitInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBarberUnitValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
