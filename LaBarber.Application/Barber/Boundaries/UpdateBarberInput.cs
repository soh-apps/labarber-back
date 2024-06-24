using LaBarber.Domain.Entities.Barber;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.Barber.Boundaries
{
    public class UpdateBarberInput : BarberInput
    {
        [SwaggerSchema(
            Title = "BarberId",
            Description = "Id do barbeiro",
            Format = "int"
        )]
        public int BarberId { get; set; } = 0;

        // TODO Verificar se não deve ser feito no BarberInput
        [SwaggerSchema(
            Title = "Status",
            Description = "Status do barbeiro",
            Format = "BarberStatus"
        )]
        public BarberStatus Status { get; set; } = BarberStatus.Inactive;
    }
}