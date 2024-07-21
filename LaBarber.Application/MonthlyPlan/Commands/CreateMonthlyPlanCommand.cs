using LaBarber.Application.MonthlyPlan.Boundaries;
using LaBarber.Application.MonthlyPlan.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.MonthlyPlan.Commands
{
    public class CreateMonthlyPlanCommand : Command<bool>
    {
        public CreateMonthlyPlanInput Input { get; set; }
        public CreateMonthlyPlanCommand(CreateMonthlyPlanInput input)
        {
            Input = input;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateMonthlyPlanValidation().Validate(Input);
            return ValidationResult.IsValid;
        }
    }
}
