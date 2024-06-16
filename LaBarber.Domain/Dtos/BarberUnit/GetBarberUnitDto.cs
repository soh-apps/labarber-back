using LaBarber.Domain.Entities.Barber;

namespace LaBarber.Domain.Dtos.BarberUnit
{
    public class GetBarberUnitDto
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

        public GetBarberUnitDto()
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
            Availabilities = new List<GetBarberUnitAvailabilityDto>();
        }

        public GetBarberUnitDto(int id, string name, string city, string state, string street, string number, string complement, string zipCode, int companyId, BarberUnitStatus status, IEnumerable<BarberUnitAvailabilityDto> availabilities)
        {
            Id = id;
            Name = name;
            City = city;
            State = state;
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            CompanyId = companyId;
            Status = status;
            Availabilities = FormatBarberUnitAvailabilitiesList(availabilities);
        }

        private IEnumerable<GetBarberUnitAvailabilityDto> FormatBarberUnitAvailabilitiesList(IEnumerable<BarberUnitAvailabilityDto> availabilitiesDto)
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
