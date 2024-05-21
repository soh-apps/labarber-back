using LaBarber.Domain.Base.Messages;
using LaBarber.Domain.Base.Messages.Notification;

namespace LaBarber.Domain.Base.Communication
{
    public interface IMediatorHandler
    {
        Task<TResponse> SendCommand<TCommand, TResponse>(TCommand command) where TCommand : Command<TResponse>;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
