using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.Credential;

namespace LaBarber.Application.Login.UseCase
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ICredentialRepository _repository;
        private readonly IMediatorHandler _handler;

        public LoginUseCase(ICredentialRepository repository, IMediatorHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public async Task AddRecoveryCode(int credentialId, string recoveryCode)
        {
            await _repository.AddPasswordRecoveryCode(credentialId, recoveryCode);
        }

        public async Task<bool> ChangePassword(string code, string password)
        {
            var credential = await _repository.GetCredentialBycode(code);
            if (credential.Id > 0)
            {
                await _repository.ChangePassword(credential.Id, password);
                return true;

            }
            else
            {
                await _handler.PublishNotification(new DomainNotification("credential", "Codigo invalido"));
                return false;
            }
        }

        public async Task<int> CreateLogin(CreateCredentialDto dto)
        {
            if (await _repository.CredentialExists(dto.Username, dto.Email))
            {
                await _handler.PublishNotification(new DomainNotification("credential", "Login ou e-mail ja utilizados"));
                return 0;
            }

            return await _repository.CreateCredential(dto);
        }

        public async Task DeleteLogin(int credentialId)
        {
            await _repository.DeleteCredential(credentialId);
        }

        public async Task<CredentialDto> GetCredentialByEmail(string email)
        {
            return await _repository.GetCredentialByEmail(email);
        }

        public async Task<LoginDto> Login(string username, string pwd)
        {
            return await _repository.Login(username, pwd);
        }
    }
}
