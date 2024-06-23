using LaBarber.Domain.Entities.Barber;

namespace LaBarber.Application.Barber.Boundaries
{
    public class UpdateBarberInput : BarberInput
    {
        public int BarberId { get; set; } = 0;

        // TODO Verificar se não deve ser feito no BarberInput
        public BarberStatus Status { get; set; } = BarberStatus.Inactive;
    }
}