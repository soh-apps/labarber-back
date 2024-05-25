using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Company.Commands.CreateCompanyUser;
using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.AppUser;
using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Company.Handlers
{
    public class CreateCompanyUserHandler : IRequestHandler<CreateCompanyUserCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly ITokenUseCase _tokenUseCase;

        public CreateCompanyUserHandler(ILoginUseCase loginUseCase, IMediatorHandler handler,
         IAppUserUseCase appUserUseCase, ITokenUseCase tokenUseCase)
        {
            _loginUseCase = loginUseCase;
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _tokenUseCase = tokenUseCase;
        }

        public async Task<bool> Handle(CreateCompanyUserCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var encryptedPassword = _tokenUseCase.EncryptPassword(input.Password);
                var createCredentialDto = new CreateCredentialDto(input.UserName, encryptedPassword, input.Email, UserType.Admin);

                var credentialId = await _loginUseCase.CreateLogin(createCredentialDto);
                if (credentialId > 0)
                {
                    var appUserDto = new CreateAppUserDto(input.Name, UserStatus.Active, DateTime.UtcNow, input.CompanyId, credentialId);
                    await _appUserUseCase.CreateAppUser(appUserDto);
                    return true;
                }

                //TODO, desfazer a credential caso a falha seja no AppUser

                await _handler.PublishNotification(new DomainNotification(request.MessageType, "Ocorreu um erro ao criar o usuário"));
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}