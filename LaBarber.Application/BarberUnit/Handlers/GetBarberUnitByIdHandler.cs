using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.BarberUnit;
using MediatR;

namespace LaBarber.Application.BarberUnit.Handlers
{
    public class GetBarberUnitByIdHandler : IRequestHandler<GetBarberUnitCommand, BarberUnitOutput>
    {
        private readonly IMediatorHandler _handler;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;

        public GetBarberUnitByIdHandler(IMediatorHandler handler, IAppUserUseCase appUserUseCase, IBarberUnitUseCase barberUnitUseCase)
        {
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _barberUnitUseCase = barberUnitUseCase;
        }

        public async Task<BarberUnitOutput> Handle(GetBarberUnitCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var user = await _appUserUseCase.GetAppUserById(request.UserId);
                var barberUnitDto = await _barberUnitUseCase.GetBarberUnitById(request.BarberUnitId);

                if ((user.CompanyId != null && user.CompanyId == barberUnitDto.CompanyId) || request.UserRole == "Master")
                {
                    var availabilitiesDto = await _barberUnitUseCase.GetBarberUnitAvailability(barberUnitDto.Id);
                    return new BarberUnitOutput(barberUnitDto, availabilitiesDto);
                }
                await _handler.PublishNotification(new DomainNotification(request.MessageType, "Usuário não possui permissão necessária."));
                return new BarberUnitOutput();
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new BarberUnitOutput();
        }
    }
}
