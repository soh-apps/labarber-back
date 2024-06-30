using LaBarber.Application.BarberUnit.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.BarberUnit
{
    public class AvailabilityInputExample : IExamplesProvider<AvailabilityInput>
    {
        public AvailabilityInput GetExamples()
        {
            return new AvailabilityInput()
            {
                WorkingDays = [1, 2, 3],
                StartingHour = new TimeSpan(8,0,0),
                EndingHour = new TimeSpan(11,30,0)
            };
        }
    }
}
