using LaBarber.Application.MonthlyPlan.Boundaries;
using LaBarber.Application.MonthlyPlan.Commands.Validation;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.MonthlyPlan.Commands
{
    public class GetMonthlyPlanByIdCommand(int entityId, int userId, string userRole) : Command<MonthlyPlanOutput>
    {
        public int Id { get; set; } = entityId;
        public int UserId { get; set; } = userId;
        public string UserRole { get; set; } = userRole;

        public override bool IsValid()
        {
            ValidationResult = new GetMonthlyPlanByIdValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}