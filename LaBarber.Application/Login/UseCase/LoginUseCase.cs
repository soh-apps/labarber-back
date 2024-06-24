using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.Credential;

namespace LaBarber.Application.Login.UseCase
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ICredentialRepository _repository;
        private readonly ILoggedUserRepository _loggedUserRepository;
        private readonly IMediatorHandler _handler;

        public LoginUseCase(ICredentialRepository repository, IMediatorHandler handler, ILoggedUserRepository loggedUserRepository)
        {
            _repository = repository;
            _handler = handler;
            _loggedUserRepository = loggedUserRepository;
        }

        public async Task AddRecoveryCode(int credentialId, string recoveryCode)
        {
            await _repository.AddPasswordRecoveryCode(credentialId, recoveryCode);
        }

        public async Task<bool> ChangeBarberProfile(int profileId, int userId)
        {
            return await _repository.ChangeBarberProfile(profileId, userId);
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

        public async Task<LoginDto> LoginById(int credentialId, string refreshToken)
        {
            var exists = await _loggedUserRepository.RefreshTokenExists(credentialId, refreshToken);
            if (exists)
            {
                return await _repository.LoginById(credentialId);
            }

            return new LoginDto();
        }

        public async Task SaveRefreshToken(int credentialId, string refreshToken)
        {
            await _loggedUserRepository.SaveUserRefreshToken(credentialId, refreshToken);
        }
    }
}
