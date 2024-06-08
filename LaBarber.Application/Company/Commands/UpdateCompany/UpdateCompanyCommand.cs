using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands.UpdateCompany.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : Command<bool>
    {
        public UpdateCompanyCommand(UpdateCompanyInput input)
        {
            Input = input;
        }
        public UpdateCompanyInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCompanyValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}