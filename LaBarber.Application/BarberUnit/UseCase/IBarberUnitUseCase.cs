using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Application.BarberUnit.UseCase
{
    public interface IBarberUnitUseCase
    {
        Task<int> CreateBarberUnit(CreateBarberUnitDto input);
        Task<bool> UpdateBarberUnit(UpdateBarberUnitDto input);
        Task<IEnumerable<BarberUnitDto>> GetBarberUnitsByCompany(int companyId);
        Task<GetBarberUnitDto> GetBarberUnitById(int barberUnitId);
        Task<bool> CreateBarberUnitManager(CreateBarberUnitManagerDto input);
        Task<bool> SetBarberUnitAvailability(IEnumerable<SetBarberUnitAvailabilityDto> availabilities, int barberUnitId);
        Task<IEnumerable<BarberUnitAvailabilityDto>> GetBarberUnitAvailability(int barberUnitId);
    }
}
