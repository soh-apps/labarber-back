using LaBarber.Domain.Dtos.Login;

namespace LaBarber.Domain.Entities.AppUser
{
    public interface IAppUserRepository
    {
        Task<LoginDto> LoginAppUser(string username, string pwd);
    }
}
