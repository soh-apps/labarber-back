using LaBarber.Application.SigningPlan.Boundaries;
using LaBarber.Application.SigningPlan.Commands.CreateSigningPlan.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.SigningPlan.Commands.CreateSigningPlan
{
    public class CreateSigningPlanCommand(SigningPlanInput input) : Command<bool>
    {
        public SigningPlanInput Input { get; set; } = input;

        public override bool IsValid()
        {
            ValidationResult = new CreateSigningPlanValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
