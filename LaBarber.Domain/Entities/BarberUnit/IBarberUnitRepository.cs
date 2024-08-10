using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Domain.Entities.BarberUnit
{
    public interface IBarberUnitRepository
    {
        Task<int> CreateBarberUnit(CreateBarberUnitDto input);
        Task<bool> UpdateBarberUnit(UpdateBarberUnitDto input);
        
        Task<BarberUnitDto> GetBarberUnitById(int barberUnitId);
        Task<IEnumerable<BarberUnitDto>> GetBarberUnitsByCompany(int companyId);
        Task<IEnumerable<BarberUnitAvailabilityDto>> GetBarberUnitAvailability(int barberUnitId);
        Task<bool> CreateBarberUnitAvailabilities(IEnumerable<BarberUnitAvailabilityDto> availabilities);
        Task<bool> DeleteAllBarberUnitAvailabilities(int barberUnitId);
        Task DeleteBarberUnitById(int id);


    }
}
