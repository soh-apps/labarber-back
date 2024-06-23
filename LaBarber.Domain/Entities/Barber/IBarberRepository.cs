using LaBarber.Domain.Dtos.Barber;

namespace LaBarber.Domain.Entities.Barber
{
    public interface IBarberRepository
    {
        Task<bool> CreateBarber(BarberDto dto);
        Task<bool> UpdateBarber(BarberDto dto);
        Task<BarberDto> GetBarberByUserId(int userId);
        Task<List<BarberDto>> GetAllBarbers(int barberUnitId);
    }
}