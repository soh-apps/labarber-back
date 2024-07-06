using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Common.Validation;
using LaBarber.Application.Service.Commands.CreateService;
using LaBarber.Application.Service.Commands.UpdateService;
using LaBarber.Application.Service.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Service;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Service.Handlers
{
    public class UpdateServiceHandler : IRequestHandler<UpdateServiceCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IServiceUseCase _useCase;
        private readonly IValidationUseCase _validationUseCase;

        public UpdateServiceHandler(IServiceUseCase useCase,
        IMediatorHandler mediatorHandler,
         IValidationUseCase validationUseCase)
        {
            _useCase = useCase;
            _mediatorHandler = mediatorHandler;
            _validationUseCase = validationUseCase;
        }

        public async Task<bool> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var realBarberUnitId = await _validationUseCase.ChecksRealBarberUnitId(input.UserId, input.BarberUnitId, input.UserRole);
                if (realBarberUnitId > 0)
                {
                    var dto = new ServiceDto(input.Id, input.Name, input.TimeToComplete, input.Value, input.CommissionPercent,
                     input.BarberUnitId, input.Description);
                    await _useCase.UpdateService(dto);
                    return true;
                }
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}