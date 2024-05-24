using LaBarber.Domain.Dtos.Login;

namespace LaBarber.Application.AppUser.UseCase
{
    public interface IAppUserUseCase
    {
        Task<LoginDto> Login(string username, string pwd);
    }
}
