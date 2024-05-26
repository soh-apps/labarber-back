using LaBarber.Domain.Dtos.Login;

namespace LaBarber.Application.Login.UseCase
{
    public interface ILoginUseCase
    {
        Task<LoginDto> Login(string username, string pwd);
        Task<int> CreateLogin(CreateCredentialDto dto);
        Task DeleteLogin(int credentialId);
        Task<CredentialDto> GetCredentialByEmail(string email);
        Task AddRecoveryCode(int credentialId, string recoveryCode);
        Task<bool> ChangePassword(string code, string password);
    }
}
