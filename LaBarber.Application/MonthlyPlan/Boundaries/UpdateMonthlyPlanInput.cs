using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.MonthlyPlan.Boundaries
{
    public class UpdateMonthlyPlanInput : MonthlyPlanInput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do plano",
            Format = "int"
        )]
        public int Id { get; set; } = 0;
    }
}