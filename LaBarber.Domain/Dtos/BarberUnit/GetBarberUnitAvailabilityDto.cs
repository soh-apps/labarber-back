namespace LaBarber.Domain.Dtos.BarberUnit
{
    public class GetBarberUnitAvailabilityDto
    {
        public IEnumerable<int> WorkingDays { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }

        public GetBarberUnitAvailabilityDto(int[] workingDays, TimeSpan startingHour, TimeSpan endingHour)
        {
            WorkingDays = workingDays;
            StartingHour = startingHour;
            EndingHour = endingHour;
        }
    }
}
