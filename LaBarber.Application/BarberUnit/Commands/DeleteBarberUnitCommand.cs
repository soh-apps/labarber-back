using LaBarber.Application.BarberUnit.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.BarberUnit.Commands
{
    public class DeleteBarberUnitCommand(int userId, string userRole, int barberUnitId) : Command<bool>
    {
        public int UserId { get; set; } = userId;
        public string UserRole { get; set; } = userRole;
        public int BarberUnitId { get; set; } = barberUnitId;

        public override bool IsValid()
        {
            ValidationResult = new DeleteBarberUnitByIdValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
