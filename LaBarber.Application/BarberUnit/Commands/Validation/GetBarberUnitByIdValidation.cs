using FluentValidation;

namespace LaBarber.Application.BarberUnit.Commands.Validation
{
    public class GetBarberUnitByIdValidation : AbstractValidator<GetBarberUnitCommand>
    {
        public GetBarberUnitByIdValidation()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Não foi possível obter dados do usuário.");

            RuleFor(x => x.UserRole)
                .NotEmpty()
                .WithMessage("Não foi possível obter dados das permissões do usuário.");

            RuleFor(x => x.BarberUnitId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Informe o id da barbearia a ser procurada.");
        }
    }
}
