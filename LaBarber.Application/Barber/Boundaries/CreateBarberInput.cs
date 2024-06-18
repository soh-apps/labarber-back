namespace LaBarber.Application.Barber.Boundaries
{
    public class CreateBarberInput
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public bool Commissioned { get; set; }
        public int BarberUnitId { get; set; }
        public int UserId { get; private set; }
        public bool IsManager { get; set; }
        public string UserRole { get; private set; }

        public CreateBarberInput()
        {
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            ZipCode = string.Empty;
            Commissioned = false;
            BarberUnitId = 0;
            UserId = 0;
            IsManager = false;
            UserRole = string.Empty;
        }

        public void SetUserRole(string userRole)
        {
            UserRole = userRole;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}
