using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.MonthlyPlan.Boundaries
{
    public class MonthlyPlanInput
    {
        [SwaggerSchema(
            Title = "Name",
            Description = "Nome do plano",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "Description",
            Description = "Descrição contendo mais informações do plano",
            Format = "string")]
        public string Description { get; set; }

        [SwaggerSchema(
            Title = "Value",
            Description = "Valor do plano",
            Format = "decimal")]
        public decimal Value { get; set; }
        public int UserId { get; private set; }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public MonthlyPlanInput()
        {
            Name = string.Empty;
            Description = string.Empty;
            Value = 0;
            UserId = 0;
        }
    }
}