using FluentValidation;

namespace LaBarber.Application.BarberUnit.Commands.Validation
{
    public class GetBarberUnitsByCompanyValidation : AbstractValidator<GetBarberUnitsByCompanyCommand>
    {
        public GetBarberUnitsByCompanyValidation()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Id do usuário obrigatório.");

            RuleFor(x => x.UserRole)
                .NotEmpty()
                .WithMessage("Role do usuário obrigatório.");
        }
    }
}
