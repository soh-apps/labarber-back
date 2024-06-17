using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Barber.Commands
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
