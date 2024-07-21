using FluentValidation;
using LaBarber.Application.MonthlyPlan.Boundaries;

namespace LaBarber.Application.MonthlyPlan.Commands.Validation
{
    public class UpdateMonthlyPlanValidation : AbstractValidator<UpdateMonthlyPlanInput>
    {
        public UpdateMonthlyPlanValidation()
        {
            RuleFor(c => c.Id)
            .NotNull().WithMessage("Id é obrigatório")
            .GreaterThan(0).WithMessage("Id é obrigatório");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome do plano é obrigatório.")
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.Value)
                .NotNull().WithMessage("Valor do plano é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("Valor do plano deve ser maior ou igual a zero.");
        }
    }
}
