using LaBarber.Domain.Dtos.AppUser;

namespace LaBarber.Application.AppUser.UseCase
{
    public interface IAppUserUseCase 
    {
        Task<bool> CreateAppUser(CreateAppUserDto dto);
    }
}