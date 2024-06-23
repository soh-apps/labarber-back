using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Barber.Handlers
{
    public class GetAllBarbersHandler : IRequestHandler<GetAllBarbersCommand, List<BarberOutput>>
    {
        private readonly IMediatorHandler _handler;
        private readonly IBarberUseCase _barberUseCase;

        public GetAllBarbersHandler(
            IMediatorHandler handler,
            IBarberUseCase barberUSerCase)
        {
            _handler = handler;
            _barberUseCase = barberUSerCase;
        }

        public async Task<List<BarberOutput>> Handle(GetAllBarbersCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                if (request.UserRole == UserType.Admin.ToString())
                {
                    int barberUnitId = request.BarberUnitId ?? 0;
                    var barbers = await _barberUseCase.GetAllBarbers(barberUnitId);

                    return barbers.Select(barber => new BarberOutput(barber)).ToList();
                }
                else
                {
                    var manager = await _barberUseCase.GetBarberByUserId(request.UserId);
                    if (manager.BarberUnitId == 0)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "Barbearia não encontrada"));
                        return [];
                    }
                    var barbers = await _barberUseCase.GetAllBarbers(manager.BarberUnitId);
                    return barbers.Select(barber => new BarberOutput(barber)).ToList();
                }
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return [];
        }
    }
}
