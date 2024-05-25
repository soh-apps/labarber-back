using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands.CreateCompanyUser.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Company.Commands.CreateCompanyUser
{
    public class CreateCompanyUserCommand : Command<bool>
    {
        public CreateCompanyUserCommand(CreateCompanyUserInput input)
        {
            Input = input;
        }
        public CreateCompanyUserInput Input { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CreateCompanyUserValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}