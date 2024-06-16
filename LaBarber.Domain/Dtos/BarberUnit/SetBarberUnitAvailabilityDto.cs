namespace LaBarber.Domain.Dtos.BarberUnit
{
    public class SetBarberUnitAvailabilityDto
    {
        public int[] WorkingDays { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }

        public SetBarberUnitAvailabilityDto(int[] workingDays, TimeSpan startingHour, TimeSpan endingHour)
        {
            WorkingDays = workingDays;
            StartingHour = startingHour;
            EndingHour = endingHour;
        }
    }
}
