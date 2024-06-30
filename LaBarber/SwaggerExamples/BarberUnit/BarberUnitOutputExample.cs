
using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.BarberUnit;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.BarberUnit
{
    public class BarberUnitOutputExample : IExamplesProvider<BarberUnitOutput>
    {
        public BarberUnitOutput GetExamples()
        {
            var workingHours = new List<GetBarberUnitAvailabilityDto>()
            {
                new GetBarberUnitAvailabilityDto([2,3,4,5], new TimeSpan(8,0,0), new TimeSpan(11,30,0)),
                new GetBarberUnitAvailabilityDto([2,3,4,5], new TimeSpan(14,0,0), new TimeSpan(18,0,0)),
            };
            return new BarberUnitOutput()
            {
                Id = 1,
                Name = "Cortes do João",
                State = "AP",
                City = "Macapá",
                Street = "Avenida Primeira",
                Number = "280",
                Complement = "",
                Availabilities = workingHours,
                CompanyId = 1,
                Status = BarberUnitStatus.Active,
                ZipCode = "68903-860"
            };
        }
    }

    public class ListBarberUnitOutputExample : IExamplesProvider<IEnumerable<BarberUnitOutput>>
    {
        public IEnumerable<BarberUnitOutput> GetExamples()
        {
            var workingHours = new List<GetBarberUnitAvailabilityDto>()
            {
                new GetBarberUnitAvailabilityDto([2,3,4,5], new TimeSpan(8,0,0), new TimeSpan(11,30,0)),
                new GetBarberUnitAvailabilityDto([2,3,4,5], new TimeSpan(14,0,0), new TimeSpan(18,0,0)),
            };
            return new List<BarberUnitOutput>() {
                new BarberUnitOutput()
                {
                    Id = 1,
                    Name = "Cortes do João",
                    State = "AP",
                    City = "Macapá",
                    Street = "Avenida Primeira",
                    Number = "280",
                    Complement = "",
                    Availabilities = workingHours,
                    CompanyId = 1,
                    Status = BarberUnitStatus.Active,
                    ZipCode = "68903-860"
                },
                new BarberUnitOutput()
                {
                    Id = 2,
                    Name = "Cortes do João - Centro",
                    State = "AP",
                    City = "Macapá",
                    Street = "Avenida 1 de Abril",
                    Number = "1155",
                    Complement = "",
                    Availabilities = workingHours,
                    CompanyId = 1,
                    Status = BarberUnitStatus.Active,
                    ZipCode = "68903-960"
                }};
        }
    }
}
