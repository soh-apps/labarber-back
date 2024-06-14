using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.RefreshToken;
using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Login.Handlers
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, LoginOutput>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ILoginUseCase _loginUseCase;
        private readonly ITokenUseCase _tokenUseCase;

        public RefreshTokenHandler(IMediatorHandler mediatorHandler
            , ILoginUseCase loginUseCase
            , ITokenUseCase tokenUseCase)
        {
            _mediatorHandler = mediatorHandler;
            _loginUseCase = loginUseCase;
            _tokenUseCase = tokenUseCase;
        }
        public async Task<LoginOutput> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var loginDto = await _loginUseCase.LoginById(input.CredentialId, request.Input.RefreshToken);
                if (loginDto.UserId > 0)
                {
                    var dto = _tokenUseCase.GenerateToken(loginDto.Name, loginDto.Role, loginDto.UserId);
                    await _loginUseCase.SaveRefreshToken(loginDto.CredentialId, dto.RefreshToken);
                    return new LoginOutput(dto.Token, dto.RefreshToken, (UserType)loginDto.ProfileId, loginDto.Name, loginDto.CredentialId);
                }
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, "credenciais inválidas."));
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new LoginOutput();
        }
    }
}
