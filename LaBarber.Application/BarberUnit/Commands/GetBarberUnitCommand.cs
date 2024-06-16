using LaBarber.Application.BarberUnit.Commands.Validation;
using LaBarber.Domain.Base.Messages;
using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Application.BarberUnit.Commands
{
    public class GetBarberUnitCommand : Command<GetBarberUnitDto>
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public int BarberUnitId { get; set; }

        public GetBarberUnitCommand()
        {
            UserId = 0;
            UserRole = string.Empty;
            BarberUnitId = 0;
        }

        public GetBarberUnitCommand(int userId, string userRole, int barberUnitId)
        {
            UserId = userId;
            UserRole = userRole;
            BarberUnitId = barberUnitId;
        }
        public override bool IsValid()
        {
            ValidationResult = new GetBarberUnitByIdValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
