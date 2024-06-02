using LaBarber.Domain.Dtos.AppUser;
using LaBarber.Domain.Entities.AppUser;

namespace LaBarber.Application.AppUser.UseCase
{
    public class AppUserUseCase : IAppUserUseCase
    {
        private readonly IAppUserRepository _repository;

        public AppUserUseCase(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAppUser(CreateAppUserDto dto)
        {
            try
            {
                await _repository.CreateAppUser(dto);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<GetAppUserDto> GetAppUserById(int id)
        {
            try
            {
                return await _repository.GetById(id);
            }
            catch
            {
                return await Task.FromResult(new GetAppUserDto());
            }
        }
    }
}