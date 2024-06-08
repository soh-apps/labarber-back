using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Domain.Entities.Barber
{
    public interface IBarberUnitRepository
    {
        Task<bool> CreateBarberUnit(CreateBarberUnitDto input);
        Task<bool> CreateBarberUnitManager(CreateBarberUnitManagerDto input);
        Task<IEnumerable<BarberUnitDto>> GetBarberUnitsByCompany(int companyId);
    }
}
