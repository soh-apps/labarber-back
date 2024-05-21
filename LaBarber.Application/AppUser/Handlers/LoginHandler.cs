using LaBarber.Application.AppUser.Commands.Login;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.AppUser.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public LoginHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }
        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                return await Task.FromResult(true);
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
