using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.BarberUnit;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class BarberUnitOutput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id da barbearia.",
            Format = "int")]
        public int Id { get; set; }

        [SwaggerSchema(
            Title = "Name",
            Description = "Nome da barbearia",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "City",
            Description = "Nome da cidade da barbearia",
            Format = "string")]
        public string City { get; set; }

        [SwaggerSchema(
            Title = "State",
            Description = "Sigla do estado da barbearia",
            Format = "string")]
        public string State { get; set; }

        [SwaggerSchema(
            Title = "Street",
            Description = "Rua da barbearia",
            Format = "string")]
        public string Street { get; set; }

        [SwaggerSchema(
            Title = "Number",
            Description = "Número do endereço da barbearia",
            Format = "int")]
        public string Number { get; set; }

        [SwaggerSchema(
            Title = "Complement",
            Description = "Complemento do endereço da barbearia",
            Format = "string")]
        public string Complement { get; set; }

        [SwaggerSchema(
            Title = "ZipCode",
            Description = "CEP da barbearia",
            Format = "XXXXX-XXX")]
        public string ZipCode { get; set; }

        [SwaggerSchema(
            Title = "CompanyId",
            Description = "Id da empresa que a barbearia pertence",
            Format = "int")]
        public int CompanyId { get; set; }

        [SwaggerSchema(
            Title = "Status",
            Description = "Estado de funcionamento atual da barbearia",
            Format = "BarberUnitStatus")]
        public BarberUnitStatus Status { get; set; }

        [SwaggerSchema(
            Title = "Availabilities",
            Description = "Lista de dias da semana e horário de funcionamento da barbearia",
            Format = "IEnumerable<GetBarberUnitAvailabilityDto>")]
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
