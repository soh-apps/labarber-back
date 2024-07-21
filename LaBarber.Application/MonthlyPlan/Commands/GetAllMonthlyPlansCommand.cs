using LaBarber.Application.MonthlyPlan.Boundaries;
using LaBarber.Application.MonthlyPlan.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.MonthlyPlan.Commands
{
    public class GetAllMonthlyPlansCommand(int entityId, string userRole) : Command<List<MonthlyPlanOutput>>
    {
        public int Id { get; set; } = entityId;
        public string UserRole { get; set; } = userRole;
        public override bool IsValid()
        {
            ValidationResult = new GetAllMonthlyPlansValidations().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
	