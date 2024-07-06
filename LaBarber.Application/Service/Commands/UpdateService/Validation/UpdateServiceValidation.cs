using FluentValidation;
using LaBarber.Application.Service.Boundaries;

namespace LaBarber.Application.Service.Commands.UpdateService.Validation
{
    public class UpdateServiceValidation : AbstractValidator<ServiceInput>
    {
        public UpdateServiceValidation()
        {
            RuleFor(x => x.Id)
            .NotNull().WithMessage("É preciso informar o id do serviço")
            .GreaterThan(0).WithMessage("É preciso informar o id do serviço");

            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome do serviço é obrigatório");

            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descrição do serviço é obrigatório");

            RuleFor(x => x.CommissionPercent)
            .NotNull().WithMessage("A porcentagem da comissão é obrigatório") //Permitindo zero
            .LessThan(100).WithMessage("Porcentagem deve estar entre 0 e 100%");

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