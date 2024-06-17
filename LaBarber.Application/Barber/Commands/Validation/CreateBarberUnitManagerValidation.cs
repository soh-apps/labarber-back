using FluentValidation;
using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Extensions;

namespace LaBarber.Application.Barber.Commands.Validation
{
    public class CreateBarberUnitManagerValidation : AbstractValidator<CreateBarberUnitManagerInput>
    {
        public CreateBarberUnitManagerValidation()
        {

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Login do usuário é obrigatório");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Senha é obrigatório");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email em formato inválido");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome do gerente é obrigatório.")
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.ZipCode)
                .ZipCode(true);

            RuleFor(x => x.State)
                .StateAcronym();

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Cidade é obrigatório.");

            RuleFor(x => x.Street)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(300)
                .WithMessage("Nome de rua inválido");

            RuleFor(x => x.Number)
                .NotEmpty()
                .WithMessage("Número do endereço é obrigatório.");

            RuleFor(x => x.BarberUnitId)
                .NotNull()
                .WithMessage("Informe a barbearia que o gerente irá atuar.")
                .GreaterThan(0)
                .WithMessage("Barbearia inválida.");

            RuleFor(x => x.AdminId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Id do administrador é obrigatório.");
        }
    }
}
