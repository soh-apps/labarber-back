using FluentValidation;

namespace LaBarber.Application.MonthlyPlan.Commands.Validation
{
    public class GetMonthlyPlanByIdValidation : AbstractValidator<GetMonthlyPlanByIdCommand>
    {
        public GetMonthlyPlanByIdValidation()
        {
            RuleFor(c => c.Id)
            .NotNull().WithMessage("Id é obrigatório")
            .GreaterThan(0).WithMessage("Id é obrigatório");
        }
    }
}