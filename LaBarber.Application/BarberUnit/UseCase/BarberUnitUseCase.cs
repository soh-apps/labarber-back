using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.BarberUnit;

namespace LaBarber.Application.BarberUnit.UseCase
{
    public class BarberUnitUseCase : IBarberUnitUseCase
    {
        private readonly IBarberUnitRepository _repository;

        public BarberUnitUseCase(IBarberUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateBarberUnit(CreateBarberUnitDto input)
        {
            return await _repository.CreateBarberUnit(input);
        }

        public async Task<bool> UpdateBarberUnit(UpdateBarberUnitDto input)
        {
            return await _repository.UpdateBarberUnit(input);
        }

        public async Task<BarberUnitDto> GetBarberUnitById(int barberUnitId)
        {
            return await _repository.GetBarberUnitById(barberUnitId);
        }

        public async Task<IEnumerable<BarberUnitDto>> GetBarberUnitsByCompany(int companyId)
        {
            return await _repository.GetBarberUnitsByCompany(companyId);
        }
        public async Task<IEnumerable<BarberUnitAvailabilityDto>> GetBarberUnitAvailability(int barberUnitId)
        {
            return await _repository.GetBarberUnitAvailability(barberUnitId);
        }

        public async Task<bool> SetBarberUnitAvailability(IEnumerable<SetBarberUnitAvailabilityDto> availabilities, int barberUnitId)
        {
            if (barberUnitId < 1) return true;
            bool deleted = await _repository.DeleteAllBarberUnitAvailabilities(barberUnitId);
            if (deleted)
            {
                var availabilitiesDto = new List<BarberUnitAvailabilityDto>();
                foreach (var availability in availabilities)
                {
                    foreach (var availabilityWorkingDay in availability.WorkingDays)
                    {
                        availabilitiesDto.Add(new BarberUnitAvailabilityDto(availabilityWorkingDay, availability.StartingHour, availability.EndingHour, barberUnitId));
                    }
                }
                var availabilitiesFiltered = GetAvailabilitiesFiltered(availabilitiesDto);
                return await _repository.CreateBarberUnitAvailabilities(availabilitiesFiltered);
            }
            return false;
        }

        private IEnumerable<BarberUnitAvailabilityDto> GetAvailabilitiesFiltered(IEnumerable<BarberUnitAvailabilityDto> availabilities)
        {
            var filtered = availabilities
                .OrderBy(x => x.StartingHour)
                .GroupBy(x => x.WorkingDay)
                .ToList();
            var result = new List<BarberUnitAvailabilityDto>();
            foreach (var availabilityByWorkingDay in filtered)
            {

                var current = availabilityByWorkingDay.ElementAt(0);
                for (int i = 1; i < availabilityByWorkingDay.Count(); i++)
                {
                    var availabilityAnalized = availabilityByWorkingDay.ElementAt(i);
                    if (availabilityAnalized.StartingHour <= current.EndingHour)
                    {
                        if (availabilityAnalized.EndingHour >= current.EndingHour)
                            current.EndingHour = availabilityAnalized.EndingHour;
                    }
                    else
                    {
                        result.Add(current);
                        current = availabilityAnalized;
                    }
                }
                result.Add(current);
            }
            return result;
        }
    }
}
