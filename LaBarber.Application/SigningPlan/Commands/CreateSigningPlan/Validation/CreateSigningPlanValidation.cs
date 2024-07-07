using FluentValidation;
using LaBarber.Application.SigningPlan.Boundaries;

namespace LaBarber.Application.SigningPlan.Commands.CreateSigningPlan.Validation
{
    public class CreateSigningPlanValidation : AbstractValidator<SigningPlanInput>
    {
        public CreateSigningPlanValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome do plano é obrigatório.");

            RuleFor(x => x.Value)
                .NotNull().WithMessage("Valor do plano é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("Valor do plano deve ser maior ou igual a zero.");

            RuleFor(x => x.PaymentType)
                .NotNull().WithMessage("Tipo de pagamento do plano é obrigatório");

            RuleFor(x => x.BarberLimit)
                .NotNull().WithMessage("Número limite de barbeiros permitidos pelo plano é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("Valor do número limite de barbeiros deve ser maior ou igual a zero.");

            RuleFor(x => x.BarberUnitLimit)
                .NotNull().WithMessage("Número limite de barbearias permitidas pelo plano é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("Valor do número limite de barbearias deve ser maior ou igual a zero.");
        }
    }
}
