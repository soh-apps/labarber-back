using LaBarber.Application.Service.Boundaries;
using LaBarber.Application.Service.Commands.CreateService.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Service.Commands.CreateService
{
    public class CreateServiceCommand(ServiceInput input) : Command<bool>
    {
        public ServiceInput Input { get; set; } = input;

        public override bool IsValid()
        {
            ValidationResult = new CreateServiceValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}