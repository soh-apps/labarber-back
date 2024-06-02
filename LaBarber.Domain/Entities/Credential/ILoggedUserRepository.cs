namespace LaBarber.Domain.Entities.Credential
{
    public interface ILoggedUserRepository
    {
        Task SaveUserRefreshToken(int credentialId, string refreshToken);
        Task<bool> RefreshTokenExists(int credentialId, string refreshToken);
    }
}