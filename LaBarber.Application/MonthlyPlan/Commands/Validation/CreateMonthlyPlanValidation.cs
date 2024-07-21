using FluentValidation;
using LaBarber.Application.MonthlyPlan.Boundaries;

namespace LaBarber.Application.MonthlyPlan.Commands.Validation
{
    public class CreateMonthlyPlanValidation : AbstractValidator<CreateMonthlyPlanInput>
    {
        public CreateMonthlyPlanValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome do plano é obrigatório");

            RuleFor(x => x.Value)
                .NotNull().WithMessage("Valor do plano é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("Valor do plano deve ser maior ou igual a zero.");
        }
    }
}
