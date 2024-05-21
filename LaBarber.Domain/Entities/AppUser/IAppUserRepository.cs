namespace LaBarber.Domain.Entities.AppUser
{
    public interface IAppUserRepository
    {
        Task<bool> LoginAppUser(string username, string pwd);
    }
}
