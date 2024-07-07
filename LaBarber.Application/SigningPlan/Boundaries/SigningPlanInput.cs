using LaBarber.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.SigningPlan.Boundaries
{
    public class SigningPlanInput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do plano da empresa, deve ser enviado em caso de update",
            Format = "int")]
        public int Id { get; set; }

        [SwaggerSchema(
            Title = "Name",
            Description = "Preencha com o nome do plano",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "Value",
            Description = "Preencha com o valor do plano",
            Format = "decimal")]
        public decimal Value { get; set; }

        [SwaggerSchema(
            Title = "PaymentType",
            Description = "Preencha com o tipo de pagamento",
            Format = "PaymentType")]
        public PaymentType PaymentType { get; set; }

        [SwaggerSchema(
            Title = "BarberUnitLimit",
            Description = "Preencha com limite de barbearias suportadas pelo plano",
            Format = "int")]
        public int BarberUnitLimit { get; set; }

        [SwaggerSchema(
            Title = "BarberLimit",
            Description = "Preencha com o limite de barbeiros suportados pelo plano",
            Format = "int")]
        public int BarberLimit { get; set; }

        public SigningPlanInput()
        {
            Id = 0;
            Name = string.Empty;
            Value = 0M;
            PaymentType = PaymentType.None;
            BarberUnitLimit = 0;
            BarberLimit = 0;
        }
    }
}
