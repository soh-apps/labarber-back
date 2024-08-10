using LaBarber.Application.Common.Validation;
using LaBarber.Application.Service.Commands.DeleteService;
using LaBarber.Application.Service.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.Service.Handlers
{
    public class DeleteServiceHandler(IServiceUseCase useCase,
    IMediatorHandler mediatorHandler,
     IValidationUseCase validationUseCase) : IRequestHandler<DeleteServiceCommand, bool>
    {
        public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {

                var service = await useCase.GetServiceById(request.Id);

                var hasPermission = await validationUseCase.UserHasPermissionOnBarberUnit(request.UserId, service.BarberUnitId, request.UserRole);
                if (hasPermission)
                {
                    await useCase.DeleteServiceById(service.Id);
                    return true;
                }
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}