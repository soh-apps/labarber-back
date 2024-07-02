
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.Service.Boundaries
{
    public class ServiceInput
    {
        public ServiceInput()
        {
            Id = 0;
            Name = string.Empty;
            TimeToComplete = null;
            Value = 0;
            CommissionPercent = 0;
            BarberUnitId = 0;
            UserId = 0;
            UserRole = string.Empty;
        }

        [SwaggerSchema(
            Title = "Id",
            Description = "Id do serviço, deve ser enviado em caso de update",
            Format = "int")]

        public int Id { get; set; }

        [SwaggerSchema(
            Title = "Name",
            Description = "Nome do serviço",
            Format = "string")]
        public string Name { get; set; }

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
            Description = "Id da barbearia, deve ser enviado em caso de admin",
            Format = "int")]
        public int BarberUnitId { get; set; }

        public int UserId { get; private set; }
        public string UserRole { get; private set; }

        public void SetUserRole(string userRole)
        {
            UserRole = userRole;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}