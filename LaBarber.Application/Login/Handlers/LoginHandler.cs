using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.Login;
using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Login.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginOutput>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ILoginUseCase _loginUseCase;
        private readonly ITokenUseCase _tokenUseCase;

        public LoginHandler(IMediatorHandler mediatorHandler
            , ILoginUseCase loginUseCase
            , ITokenUseCase tokenUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _loginUseCase = loginUseCase;
            _tokenUseCase = tokenUseCase;
        }
        public async Task<LoginOutput> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var encryptedPassword = _tokenUseCase.EncryptPassword(request.Input.Password);
                var loginDto = await _loginUseCase.Login(request.Input.Username, encryptedPassword);
                if (loginDto.UserId > 0)
                {
                    var dto = _tokenUseCase.GenerateToken(loginDto.Name, loginDto.Role, loginDto.UserId);
                    await _loginUseCase.SaveRefreshToken(loginDto.CredentialId, dto.RefreshToken);
                    return new LoginOutput(dto.Token, dto.RefreshToken, (UserType)loginDto.ProfileId, loginDto.Name, loginDto.CredentialId);
                }
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, "Usuário ou senha inválidos."));
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new LoginOutput();
        }
    }
}
