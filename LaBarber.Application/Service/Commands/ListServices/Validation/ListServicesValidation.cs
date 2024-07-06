using FluentValidation;

namespace LaBarber.Application.Service.Commands.ListServices.Validation
{
    public class ListServicesValidation : AbstractValidator<ListServicesCommand>
    {
        public ListServicesValidation()
        {
            When(x => x.Role == "Admin", () =>
            {
                RuleFor(x => x.BarberUnitId)
                .NotNull().WithMessage("É preciso informar a unidade")
                .GreaterThan(0).WithMessage("É preciso informar a unidade");
            });

            RuleFor(x => x.UserId)
            .NotNull().WithMessage("É preciso estar logado")
            .GreaterThan(0).WithMessage("É preciso estar logado");
        }
    }
}