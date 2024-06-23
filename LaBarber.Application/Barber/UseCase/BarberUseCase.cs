using LaBarber.Domain.Dtos.Barber;
using LaBarber.Domain.Entities.Barber;

namespace LaBarber.Application.Barber.UseCase
{
    public class BarberUseCase : IBarberUseCase
    {
        private readonly IBarberRepository _repository;

        public BarberUseCase(IBarberRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateBarber(CreateBarberDto input)
        {
            return await _repository.CreateBarber(input);
        }

        public async Task<List<BarberDto>> GetAllBarbers(int barberUnitId)
        {
            return await _repository.GetAllBarbers(barberUnitId);
        }

        public async Task<BarberDto> GetBarberByUserId(int userId)
        {
            return await _repository.GetBarberByUserId(userId);
        }
    }
}