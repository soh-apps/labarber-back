using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Barber.Commands
{
    public class GetAllBarbersCommand(int userId, int? barberUnitId, string role) : Command<List<BarberOutput>>
    {
        public int UserId { get; set; } = userId;
        public int? BarberUnitId { get; set; } = barberUnitId;
        public string UserRole { get; set; } = role;

        public override bool IsValid()
        {
            ValidationResult = new GetAllBarbersValidations().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
