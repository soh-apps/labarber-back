using LaBarber.Domain.Dtos.Login;

namespace LaBarber.Domain.Entities.Credential
{
    public interface ICredentialRepository
    {
        Task<LoginDto> Login(string username, string pwd);
    }
}
