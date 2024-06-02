using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Domain.Entities.Barber
{
    public interface IBarberUnitRepository
    {
        Task<bool> CreateBarberUnitAsync(CreateBarberUnitDto input);
    }
}
