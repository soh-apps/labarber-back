using LaBarber.Application.BarberUnit.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.BarberUnit
{
    public class UpdateBarberUnitInputExample : IExamplesProvider<UpdateBarberUnitInput>
    {
        public UpdateBarberUnitInput GetExamples()
        {
            var workingHours = new List<AvailabilityInput>()
            {
                new AvailabilityInput([2,3,4,5], new TimeSpan(8,0,0), new TimeSpan(11,30,0)),
                new AvailabilityInput([2,3,4,5], new TimeSpan(14,0,0), new TimeSpan(18,0,0)),
            };
            return new UpdateBarberUnitInput(1, "João cortes - Araxá", "Macapá", "AP", "Avenida Primeira", "230", "", "68903-860", workingHours);
        }
    }
}
