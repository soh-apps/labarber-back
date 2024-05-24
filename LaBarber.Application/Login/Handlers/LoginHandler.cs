using LaBarber.Application.Login.Commands.Login;
using LaBarber.Application.AppUser.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;
using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Token;
using LaBarber.Domain.Enums;

namespace LaBarber.Application.Login.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginOutput>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly ITokenUseCase _tokenUseCase;

        public LoginHandler(IMediatorHandler mediatorHandler
            , IAppUserUseCase appUserUseCase
            , ITokenUseCase tokenUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _appUserUseCase = appUserUseCase;
            _tokenUseCase = tokenUseCase;
        }
        public async Task<LoginOutput> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var encryptedPassword = _tokenUseCase.EncryptPassword(request.Input.Password);
                var loginDto = await _appUserUseCase.Login(request.Input.Username, encryptedPassword);
                if (loginDto.UserId > 0)
                {
                    var token = _tokenUseCase.GenerateToken(loginDto.Name, loginDto.Role, loginDto.UserId);
                    return new LoginOutput(token, string.Empty, UserType.Admin, loginDto.Name);
                }
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new LoginOutput();
        }
    }
}
