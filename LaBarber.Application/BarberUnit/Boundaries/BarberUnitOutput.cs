using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.BarberUnit;

namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class BarberUnitOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public int CompanyId { get; set; }
        public BarberUnitStatus Status { get; set; }
        public IEnumerable<GetBarberUnitAvailabilityDto> Availabilities { get; set; }

        public BarberUnitOutput()
        {
            Id = 0;
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            ZipCode = string.Empty;
            CompanyId = 0;
            Status = BarberUnitStatus.Inactive;
            Availabilities = [];
        }

        public BarberUnitOutput(BarberUnitDto dto, IEnumerable<BarberUnitAvailabilityDto> availabilities)
        {
            Id = dto.Id;
            Name = dto.Name;
            City = dto.City;
            State = dto.State;
            Street = dto.Street;
            Number = dto.Number;
            Complement = dto.Complement;
            ZipCode = dto.ZipCode;
            CompanyId = dto.CompanyId;
            Status = dto.Status;
            Availabilities = FormatBarberUnitAvailabilitiesList(availabilities);
        }

        public BarberUnitOutput(BarberUnitDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            City = dto.City;
            State = dto.State;
            Street = dto.Street;
            Number = dto.Number;
            Complement = dto.Complement;
            ZipCode = dto.ZipCode;
            CompanyId = dto.CompanyId;
            Status = dto.Status;
            Availabilities = [];
        }

        private static IEnumerable<GetBarberUnitAvailabilityDto> FormatBarberUnitAvailabilitiesList(IEnumerable<BarberUnitAvailabilityDto> availabilitiesDto)
        {
            var result = new List<GetBarberUnitAvailabilityDto>();
            foreach (var availabilityDto in availabilitiesDto)
            {
                var availabilityInSameWorkingHours = result.Where(r => r.StartingHour == availabilityDto.StartingHour && r.EndingHour == availabilityDto.EndingHour);
                if (availabilityInSameWorkingHours.Any())
                {
                    var availability = availabilityInSameWorkingHours.First();
                    availability.WorkingDays = availability.WorkingDays.Append(availabilityDto.WorkingDay);
                }
                else result.Add(new GetBarberUnitAvailabilityDto([availabilityDto.WorkingDay], availabilityDto.StartingHour, availabilityDto.EndingHour));
            }
            return result;
        }
    }
}
