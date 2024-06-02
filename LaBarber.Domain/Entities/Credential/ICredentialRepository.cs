using LaBarber.Domain.Dtos.Login;

namespace LaBarber.Domain.Entities.Credential
{
    public interface ICredentialRepository
    {
        Task<LoginDto> Login(string username, string pwd);
        Task<LoginDto> LoginById(int credentialId);
        Task<int> CreateCredential(CreateCredentialDto dto);
        Task<bool> CredentialExists(string username, string email);
        Task DeleteCredential(int id);
        Task<CredentialDto> GetCredentialByEmail(string email);
        Task<CredentialDto> GetCredentialBycode(string code);
        Task<bool> AddPasswordRecoveryCode(int id, string code);
        Task<bool> ChangePassword(int Id, string password);
    }
}
