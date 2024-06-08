using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Application.BarberUnit.UseCase
{
    public interface IBarberUnitUseCase
    {
        Task<bool> CreateBarberUnit(CreateBarberUnitDto input);
        Task<IEnumerable<BarberUnitDto>> GetBarberUnitsByCompany(int companyId);
        Task<bool> CreateBarberUnitManager(CreateBarberUnitManagerDto input);
    }
}
