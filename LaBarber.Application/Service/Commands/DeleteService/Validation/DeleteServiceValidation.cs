using FluentValidation;

namespace LaBarber.Application.Service.Commands.DeleteService.Validation
{
    public class DeleteServiceValidation : AbstractValidator<DeleteServiceCommand>
    {
        public DeleteServiceValidation()
        {
            RuleFor(x => x.Id)
            .NotNull().WithMessage("É preciso informar o serviço")
            .GreaterThan(0).WithMessage("É preciso informar o serviço");

            RuleFor(x => x.UserId)
            .NotNull().WithMessage("É preciso estar logado")
            .GreaterThan(0).WithMessage("É preciso estar logado");

        }
    }
}
