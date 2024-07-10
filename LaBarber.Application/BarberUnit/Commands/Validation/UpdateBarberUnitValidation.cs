using FluentValidation;
using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.Extensions;

namespace LaBarber.Application.BarberUnit.Commands.Validation
{
    public class UpdateBarberUnitValidation : AbstractValidator<UpdateBarberUnitInput>
    {
        public UpdateBarberUnitValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Informe a barberia a ser atualizada");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome da barbearia é obrigatório.");

            RuleFor(x => x.ZipCode)
                .ZipCode(false);

            RuleFor(x => x.State)
                .StateAcronym();

            RuleFor(x => x.City)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("Nome de cidade inválido.");

            RuleFor(x => x.Street)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(300)
                .WithMessage("Nome de rua inválido");

            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("Número do endereço é obrigatório.");

            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Id usuário obrigatório.");
        }
    }
}
