using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands.CreateCompany.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Company.Commands
{
    public class CreateCompanyCommand : Command<bool>
    {
        public CreateCompanyCommand(CreateCompanyInput input)
        {
            Input = input;
        }
        public CreateCompanyInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateCompanyValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}