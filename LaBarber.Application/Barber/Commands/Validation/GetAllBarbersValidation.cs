using FluentValidation;

namespace LaBarber.Application.Barber.Commands.Validation
{
    public class GetAllBarbersValidations : AbstractValidator<GetAllBarbersCommand>
    {
        public GetAllBarbersValidations()
        {
            When(x => x.UserRole == "Admin", () =>
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