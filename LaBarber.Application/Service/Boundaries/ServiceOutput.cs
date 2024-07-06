using LaBarber.Domain.Dtos.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.Service.Boundaries
{
    public class ServiceOutput
    {
        public ServiceOutput()
        {
            Id = 0;
            Name = string.Empty;
            TimeToComplete = null;
            Value = 0;
            CommissionPercent = 0;
            BarberUnitId = 0;
            Description = string.Empty;
        }

        public ServiceOutput(ServiceDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            TimeToComplete = dto.TimeToComplete;
            CommissionPercent = dto.CommissionPercent;
            BarberUnitId = dto.BarberUnitId;
            Description = dto.Description;
            Value = dto.Value;
        }

        [SwaggerSchema(
            Title = "Id",
            Description = "Id do serviço",
            Format = "int")]

        public int Id { get; set; }

        [SwaggerSchema(
            Title = "Name",
            Description = "Nome do serviço",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "Description",
            Description = "Descrição do serviço",
            Format = "string")]
        public string Description { get; set; }

        [SwaggerSchema(
            Title = "TimeToComplete",
            Description = "Tempo médio para completar o serviço",
            Format = "TimeSpan")]
        public TimeSpan? TimeToComplete { get; set; }

        [SwaggerSchema(
            Title = "Value",
            Description = "valor do serviço",
            Format = "decimal")]
        public decimal Value { get; set; }

        [SwaggerSchema(
            Title = "CommissionPercent",
            Description = "Porcentagem de comissão ao barbeiro",
            Format = "int")]
        public int CommissionPercent { get; set; }

        [SwaggerSchema(
            Title = "BarberUnitId",
            Description = "Id da barbearia",
            Format = "int")]
        public int BarberUnitId { get; set; }
    }
}