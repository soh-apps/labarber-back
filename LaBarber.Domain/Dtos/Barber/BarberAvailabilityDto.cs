namespace LaBarber.Domain.Dtos.Barber
{
    public class BarberAvailabilityDto
    {
        public int WorkingDay { get; set; }
        public TimeSpan StartingHour { get; set; }
        public TimeSpan EndingHour { get; set; }
        public int BarberId { get; set; }

        public BarberAvailabilityDto(int workingDay, TimeSpan startingHour, TimeSpan endingHour, int barberId)
        {
            WorkingDay = workingDay;
            StartingHour = startingHour;
            EndingHour = endingHour;
            BarberId = barberId;
        }
    }
}
