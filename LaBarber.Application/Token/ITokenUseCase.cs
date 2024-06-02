using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Enums;

namespace LaBarber.Application.Token
{
    public interface ITokenUseCase
    {
        string EncryptPassword(string password);
        TokenDto GenerateToken(string name, string role, int userId);
        string GenerateRecoveryCode();
    }
}
