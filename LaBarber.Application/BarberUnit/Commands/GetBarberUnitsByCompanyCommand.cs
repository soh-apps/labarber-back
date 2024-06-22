using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.BarberUnit.Commands
{
    public class GetBarberUnitsByCompanyCommand : Command<IEnumerable<BarberUnitOutput>>
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public int? CompanyId { get; set; }

        public GetBarberUnitsByCompanyCommand()
        {
            UserId = 0;
            UserRole = string.Empty;
            CompanyId = null;
        }

        public GetBarberUnitsByCompanyCommand(int userId, string userRole, int? companyId)
        {
            UserId = userId;
            UserRole = userRole;
            CompanyId = companyId;
        }
        public override bool IsValid()
        {
            ValidationResult = new GetBarberUnitsByCompanyValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
