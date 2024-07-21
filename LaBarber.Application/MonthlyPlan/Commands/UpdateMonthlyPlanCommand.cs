using LaBarber.Application.MonthlyPlan.Boundaries;
using LaBarber.Application.MonthlyPlan.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.MonthlyPlan.Commands
{
    public class UpdateMonthlyPlanCommand(UpdateMonthlyPlanInput input) : Command<bool>
    {
        public UpdateMonthlyPlanInput Input { get; set; } = input;

        public override bool IsValid()
        {
            ValidationResult = new UpdateMonthlyPlanValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
