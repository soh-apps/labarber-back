using LaBarber.Domain.Dtos.Login;

namespace LaBarber.Application.Login.UseCase
{
    public interface ILoginUseCase
    {
        Task<LoginDto> Login(string username, string pwd);
    }
}
