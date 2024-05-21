using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Base.Messages;
using MediatR;

namespace LaBarber.Domain.Base.Communication
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);
        }

        public async Task<TResponse> SendCommand<TCommand, TResponse>(TCommand command) where TCommand : Command<TResponse>
        {
            return await _mediator.Send(command);
        }
    }
}
