using LaBarber.Domain.Dtos.Barber;

namespace LaBarber.Application.Barber.UseCase
{
    public interface IBarberUseCase 
    {
        Task<bool> CreateBarber(CreateBarberDto input);
        Task<BarberDto> GetBarberByUserId(int userId);
        Task<List<BarberDto>> GetAllBarbers(int barberUnitId);
    }
}