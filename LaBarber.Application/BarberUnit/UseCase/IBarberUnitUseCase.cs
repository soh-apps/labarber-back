using LaBarber.Domain.Dtos.BarberUnit;

namespace LaBarber.Application.BarberUnit.UseCase
{
    public interface IBarberUnitUseCase
    {
        Task<bool> CreateBarberUnit(CreateBarberUnitDto input);
    }
}
