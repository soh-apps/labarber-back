using LaBarber.Domain.Enums;

namespace LaBarber.Application.Token
{
    public interface ITokenUseCase
    {
        string EncryptPassword(string password);
        string GenerateToken(string name, string role, int userId);
        string GenerateRecoveryCode();
    }
}
