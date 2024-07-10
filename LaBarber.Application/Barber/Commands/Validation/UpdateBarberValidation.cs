using FluentValidation;
using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Extensions;

namespace LaBarber.Application.Barber.Commands.Validation
{
    public class UpdateBarberValidation : AbstractValidator<UpdateBarberInput>
    {
        public UpdateBarberValidation()
        {
            RuleFor(x => x.BarberId)
                .NotNull().WithMessage("Id do Barbeiro é obrigatório")
                .GreaterThan(0).WithMessage("Id do Barbeiro é obrigatório");
            
            RuleFor(x => x.Status)
                .NotNull().WithMessage("Status é obrigatório")
                .IsInEnum().WithMessage("Status inválido");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome do gerente é obrigatório.")
                .MinimumLength(2)
                .MaximumLength(100);

            RuleFor(x => x.ZipCode)
                .ZipCode(false);

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

            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("É preciso estar logado.");
                        
            RuleFor(x => x.UserRole)
                .NotEmpty()
                .WithMessage("É preciso estar logado.");
            
            RuleFor(x => x.IsManager)
                .NotNull()
                .WithMessage("Informe se o usuário é manager ou não");
        }
    }
}
