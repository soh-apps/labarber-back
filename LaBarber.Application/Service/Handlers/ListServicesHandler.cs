using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Common.Validation;
using LaBarber.Application.Service.Boundaries;
using LaBarber.Application.Service.Commands.GetService;
using LaBarber.Application.Service.Commands.ListServices;
using LaBarber.Application.Service.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Service.Handlers
{
    public class ListServicesHandler : IRequestHandler<ListServicesCommand, List<ServiceOutput>>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IServiceUseCase _useCase;
        private readonly IValidationUseCase _validationUseCase;

        public ListServicesHandler(IServiceUseCase useCase,
        IMediatorHandler mediatorHandler,
         IValidationUseCase validationUseCase)
        {
            _useCase = useCase;
            _mediatorHandler = mediatorHandler;
            _validationUseCase = validationUseCase;
        }

        public async Task<List<ServiceOutput>> Handle(ListServicesCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {

                var realBarberUnitId = await _validationUseCase.ChecksRealBarberUnitId(request.UserId, request.BarberUnitId ?? 0, request.Role);

                if (realBarberUnitId > 0)
                {
                    var services = await _useCase.GetServicesByBarberUnit(realBarberUnitId);
                    return services.Select(s => new ServiceOutput(s)).ToList();
                }
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return [];
        }
    }
}