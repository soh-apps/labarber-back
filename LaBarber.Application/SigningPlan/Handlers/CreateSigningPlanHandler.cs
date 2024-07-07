using LaBarber.Application.SigningPlan.Commands.CreateSigningPlan;
using LaBarber.Application.SigningPlan.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.SigningPlan;
using MediatR;

namespace LaBarber.Application.SigningPlan.Handlers
{
    public class CreateSigningPlanHandler : IRequestHandler<CreateSigningPlanCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ISigningPlanUseCase _signingPlanUseCase;

        public CreateSigningPlanHandler(IMediatorHandler mediatorHandler, ISigningPlanUseCase signingPlanUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _signingPlanUseCase = signingPlanUseCase;
        }

        public async Task<bool> Handle(CreateSigningPlanCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var dto = new SigningPlanDto(input.Id, input.Name, input.Value, input.PaymentType, input.BarberUnitLimit, input.BarberLimit);
                await _signingPlanUseCase.CreateSigningPlan(dto);
                return true;
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
