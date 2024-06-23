using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.Barber.Handlers
{
    public class GetBarberByIdHandler : IRequestHandler<GetBarberByIdCommand, BarberOutput>
    {
        private readonly IMediatorHandler _handler;
        private readonly IBarberUseCase _barberUseCase;

        public GetBarberByIdHandler(IBarberUseCase barberUseCase, IMediatorHandler handler)
        {
            _barberUseCase = barberUseCase;
            _handler = handler;
        }

        public async Task<BarberOutput> Handle(GetBarberByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var barber = await _barberUseCase.GetBarberByUserId(request.Id);

                return new BarberOutput(barber);

            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new BarberOutput();
        }
    }
}