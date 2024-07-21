using LaBarber.Domain.Dtos.MonthlyPlan;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.MonthlyPlan.Boundaries
{
    public class MonthlyPlanOutput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do plano",
            Format = "int")]
        public int Id { get; set; }

        [SwaggerSchema(
            Title = "Name",
            Description = "Nome do plano",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "Description",
            Description = "Descrição do plano",
            Format = "string")]
        public string Description { get; set; }

        [SwaggerSchema(
            Title = "Value",
            Description = "Valor do plano",
            Format = "decimal")]
        public decimal Value { get; set; }

        public MonthlyPlanOutput()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Value = 0;
        }

        public MonthlyPlanOutput(MonthlyPlanDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Description = dto.Description;
            Value = dto.Value;
        }
    }
}