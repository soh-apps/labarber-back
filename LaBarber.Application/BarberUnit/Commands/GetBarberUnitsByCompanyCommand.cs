using Amazon.DynamoDBv2.Model;
using LaBarber.Application.BarberUnit.Commands.Validation;
using LaBarber.Domain.Base.Messages;
using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Application.BarberUnit.Commands
{
    public class GetBarberUnitsByCompanyCommand : Command<IEnumerable<BarberUnitDto>>
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public int CompanyId { get; set; }

        public GetBarberUnitsByCompanyCommand()
        {
            UserId = 0;
            UserRole = string.Empty;
            CompanyId = 0;
        }

        public GetBarberUnitsByCompanyCommand(int userId, string userRole, int companyId)
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
