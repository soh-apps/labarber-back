using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.BarberUnit.Handlers
{
    public class DeleteBarberUnitHandler(
        IMediatorHandler handler,
        IAppUserUseCase appUserUseCase,
        IBarberUnitUseCase barberUnitUseCase) : IRequestHandler<DeleteBarberUnitCommand, bool>
    {
        public async Task<bool> Handle(DeleteBarberUnitCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var user = await appUserUseCase.GetAppUserById(request.UserId);
                var barberUnitDto = await barberUnitUseCase.GetBarberUnitById(request.BarberUnitId);

                if ((user.CompanyId != null && user.CompanyId == barberUnitDto.CompanyId) || request.UserRole == "Master")
                {
                    await barberUnitUseCase.DeleteBarberUnitById(barberUnitDto.Id);
                    return true;
                }
                await handler.PublishNotification(new DomainNotification(request.MessageType, "Usuário não possui permissão necessária."));
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
