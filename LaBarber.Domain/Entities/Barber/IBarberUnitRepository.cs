using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Domain.Entities.Barber
{
    public interface IBarberUnitRepository
    {
        Task<int> CreateBarberUnit(CreateBarberUnitDto input);
        Task<bool> UpdateBarberUnit(UpdateBarberUnitDto input);
        Task<bool> CreateBarberUnitManager(CreateBarberUnitManagerDto input);
        Task<BarberUnitDto> GetBarberUnitById(int barberUnitId);
        Task<IEnumerable<BarberUnitDto>> GetBarberUnitsByCompany(int companyId);
        Task<IEnumerable<BarberUnitAvailabilityDto>> GetBarberUnitAvailability(int barberUnitId);
        Task<bool> CreateBarberUnitAvailabilities(IEnumerable<CreateBarberUnitAvailabilityDto> availabilities);
        Task<bool> DeleteAllBarberUnitAvailabilities(int barberUnitId);
    }
}
