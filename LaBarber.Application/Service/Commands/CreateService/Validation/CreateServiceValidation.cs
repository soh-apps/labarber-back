using FluentValidation;
using LaBarber.Application.Service.Boundaries;

namespace LaBarber.Application.Service.Commands.CreateService.Validation
{
    public class CreateServiceValidation : AbstractValidator<ServiceInput>
    {
        public CreateServiceValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome do serviço é obrigatório");

            RuleFor(x => x.CommissionPercent)
            .NotNull().WithMessage("A porcentagem da comissão é obrigatório"); //Permitindo zero

            RuleFor(x => x.Value)
            .NotNull().WithMessage("Valor obrigatório")
            .GreaterThan(0).WithMessage("Valor obrigatório");

            RuleFor(x => x.TimeToComplete)
            .NotNull().WithMessage("Tempo para completar é obrigatório");

            RuleFor(x => x.UserId)
            .NotNull().WithMessage("É preciso estar logado")
            .GreaterThan(0).WithMessage("É preciso estar logado");

            When(x => x.UserRole == "Admin", () =>
            {
                RuleFor(x => x.BarberUnitId)
                .NotNull().WithMessage("É preciso informar a unidade")
                .GreaterThan(0).WithMessage("É preciso informar a unidade");
            });
        }
    }
}