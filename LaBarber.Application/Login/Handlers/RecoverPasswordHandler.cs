using LaBarber.Application.Login.Commands.RecoverPassword;
using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.Login.Handlers
{
    public class RecoverPasswordHandler : IRequestHandler<RecoverPasswordCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ILoginUseCase _loginUseCase;
        private readonly ITokenUseCase _tokenUseCase;

        public RecoverPasswordHandler(ILoginUseCase loginUseCase, IMediatorHandler mediatorHandler, ITokenUseCase tokenUseCase)
        {
            _loginUseCase = loginUseCase;
            _mediatorHandler = mediatorHandler;
            _tokenUseCase = tokenUseCase;
        }

        public async Task<bool> Handle(RecoverPasswordCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var encryptedPassword = _tokenUseCase.EncryptPassword(request.Input.Password);
                var success = await _loginUseCase.ChangePassword(request.Input.Code, encryptedPassword);

                if (success)
                    return true;

                return false;

            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}