namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class AvailabilityInput
    {
        public int[] WorkingDays { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }

        public AvailabilityInput()
        {
            WorkingDays = [];
            StartingHour = TimeSpan.Zero;
            EndingHour = TimeSpan.Zero;
        }
    }
}
