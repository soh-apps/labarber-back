using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands.GetCompanyById.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Company.Commands.GetCompanyById
{
    public class GetCompanyByIdCommand : Command<CompanyOutput>
    {
        public GetCompanyByIdCommand(int companyId, int userId)
        {
            CompanyId = companyId;
            UserId = userId;
        }

        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new GetCompanyByIdValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}