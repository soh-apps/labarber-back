using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.Barber;

namespace LaBarber.Application.BarberUnit.UseCase
{
    public class BarberUnitUseCase : IBarberUnitUseCase
    {
        private readonly IBarberUnitRepository _repository;

        public BarberUnitUseCase(IBarberUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateBarberUnit(CreateBarberUnitDto input)
        {
            return await _repository.CreateBarberUnit(input);
        }

        public async Task<bool> CreateBarberUnitManager(CreateBarberUnitManagerDto input)
        {
            return await _repository.CreateBarberUnitManager(input);
        }

        public async Task<IEnumerable<BarberUnitDto>> GetBarberUnitsByCompany(int companyId)
        {
            return await _repository.GetBarberUnitsByCompany(companyId);
        }
    }
}
