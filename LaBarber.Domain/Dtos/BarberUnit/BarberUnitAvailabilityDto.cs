namespace LaBarber.Domain.Dtos.BarberUnit
{
    public class BarberUnitAvailabilityDto
    {
        public int WorkingDay { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }
        public int BarberUnitId { get; set; }

        public BarberUnitAvailabilityDto(int workingDay, TimeSpan startingHour, TimeSpan endingHour, int barberUnitId)
        {
            WorkingDay = workingDay;
            StartingHour = startingHour;
            EndingHour = endingHour;
            BarberUnitId = barberUnitId;
        }
    }
}
