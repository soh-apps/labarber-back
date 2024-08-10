using LaBarber.Application.Common.Validation;
using LaBarber.Application.Service.Boundaries;
using LaBarber.Application.Service.Commands.GetService;
using LaBarber.Application.Service.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.Service.Handlers
{
    public class GetServiceHandler : IRequestHandler<GetServiceCommand, ServiceOutput>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IServiceUseCase _useCase;
        private readonly IValidationUseCase _validationUseCase;

        public GetServiceHandler(IServiceUseCase useCase,
        IMediatorHandler mediatorHandler,
         IValidationUseCase validationUseCase)
        {
            _useCase = useCase;
            _mediatorHandler = mediatorHandler;
            _validationUseCase = validationUseCase;
        }

        public async Task<ServiceOutput> Handle(GetServiceCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {

                var service = await _useCase.GetServiceById(request.Id);

                var hasPermission = await _validationUseCase.UserHasPermissionOnBarberUnit(request.UserId, service.BarberUnitId, request.UserRole);
                if (hasPermission)
                    return new ServiceOutput(service);
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new ServiceOutput();
        }
    }
}