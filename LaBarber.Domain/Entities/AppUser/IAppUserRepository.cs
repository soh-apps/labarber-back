using LaBarber.Domain.Dtos.AppUser;

namespace LaBarber.Domain.Entities.AppUser
{
    public interface IAppUserRepository
    {
        Task CreateAppUser(CreateAppUserDto dto);
        Task<GetAppUserDto> GetById(int id);
    }
}