using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class AvailabilityInput
    {
        [SwaggerSchema(
            Title = "WorkingDays",
            Description = "Preencha com os dias da semana do atendimento da barbearia (começando em 1: domingo e terminando em 7: sábado)",
            Format = "int[]")]
        public int[] WorkingDays { get; set; }

        [SwaggerSchema(
            Title = "StartingHour",
            Description = "Preencha com o horário de início do atendimento da barbearia",
            Format = "XX:XX:XX")]
        public TimeSpan StartingHour { get; set; }

        [SwaggerSchema(
            Title = "EndingHour",
            Description = "Preencha com o horário de fim de atendimento da barbearia",
            Format = "XX:XX:XX")]
        public TimeSpan EndingHour { get; set; }

        public AvailabilityInput()
        {
            WorkingDays = [];
            StartingHour = TimeSpan.Zero;
            EndingHour = TimeSpan.Zero;
        }

        public AvailabilityInput(int[] workingDays, TimeSpan startingHour, TimeSpan endingHour)
        {
            WorkingDays = workingDays;
            StartingHour = startingHour;
            EndingHour = endingHour;
        }
    }
}
