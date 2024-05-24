using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.AppUser;

namespace LaBarber.Application.AppUser.UseCase
{
    public class AppUserUseCase : IAppUserUseCase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserUseCase(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<LoginDto> Login(string username, string pwd)
        {
            return await _appUserRepository.LoginAppUser(username, pwd);
        }
    }
}
