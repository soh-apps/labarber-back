namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class UpdateBarberUnitAvailabilityInput
    {
        public int[] WorkingDays { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }

        public UpdateBarberUnitAvailabilityInput()
        {
            WorkingDays = Array.Empty<int>();
            StartingHour = TimeSpan.Zero;
            EndingHour = TimeSpan.Zero;
        }
    }
}
