using LaBarber.Application.Service.Boundaries;
using LaBarber.Application.Service.Commands.UpdateService.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Service.Commands.UpdateService
{
    public class UpdateServiceCommand(ServiceInput input) : Command<bool>
    {
        public ServiceInput Input { get; set; } = input;

        public override bool IsValid()
        {
            ValidationResult = new UpdateServiceValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}