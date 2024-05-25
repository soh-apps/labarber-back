using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.Credential;

namespace LaBarber.Application.Login.UseCase
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly ICredentialRepository _repository;

        public LoginUseCase(ICredentialRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateLogin(CreateCredentialDto dto)
        {
            return await _repository.CreateCredential(dto);
        }

        public async Task<LoginDto> Login(string username, string pwd)
        {
            return await _repository.Login(username, pwd);
        }
    }
}
