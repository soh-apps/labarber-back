using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Common.Validation;
using LaBarber.Application.Service.Commands.CreateService;
using LaBarber.Application.Service.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Service;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Service.Handlers
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IServiceUseCase _useCase;
        private readonly IValidationUseCase _validationUseCase;

        public CreateServiceHandler(IServiceUseCase useCase,
        IMediatorHandler mediatorHandler, IValidationUseCase validationUseCase)
        {
            _useCase = useCase;
            _mediatorHandler = mediatorHandler;
            _validationUseCase = validationUseCase;
        }

        public async Task<bool> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var realBarberUnitId = await _validationUseCase.ChecksRealBarberUnitId(input.UserId, input.BarberUnitId, input.UserRole);

                if (realBarberUnitId > 0)
                {
                    var dto = new ServiceDto(0, input.Name, input.TimeToComplete, input.Value, input.CommissionPercent,
                     realBarberUnitId, input.Description);
                    await _useCase.CreateService(dto);
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