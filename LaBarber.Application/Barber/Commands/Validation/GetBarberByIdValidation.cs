using FluentValidation;

namespace LaBarber.Application.Barber.Commands.Validation
{
    public class GetBarberByIdValidation : AbstractValidator<GetBarberByIdCommand>
    {
        public GetBarberByIdValidation()
        {
            RuleFor(c => c.Id)
            .NotNull().WithMessage("Id do barbeiro é obrigatório")
            .GreaterThan(0).WithMessage("Id do barbeiro é obrigatório");
        }
    }
}