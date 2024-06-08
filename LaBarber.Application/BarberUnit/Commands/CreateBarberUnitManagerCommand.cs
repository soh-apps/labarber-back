using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.BarberUnit.Commands
{
    public class CreateBarberUnitManagerCommand : Command<bool>
    {
        public CreateBarberUnitManagerInput Input { get; set; }
        public CreateBarberUnitManagerCommand(CreateBarberUnitManagerInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateBarberUnitManagerValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
