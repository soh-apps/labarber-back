using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.Credential;

namespace LaBarber.Application.Login.UseCase
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ICredentialRepository _appUserRepository;

        public LoginUseCase(ICredentialRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<LoginDto> Login(string username, string pwd)
        {
            return await _appUserRepository.Login(username, pwd);
        }
    }
}
