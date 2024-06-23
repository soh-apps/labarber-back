namespace LaBarber.Application.Barber.Boundaries
{
    public class CreateBarberInput : BarberInput
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
