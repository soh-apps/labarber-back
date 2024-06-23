using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Barber.Commands
{
    public class GetBarberByIdCommand(int barberId) : Command<BarberOutput>
    {
        public int Id { get; set; } = barberId;

        public override bool IsValid()
        {
            ValidationResult = new GetBarberByIdValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}