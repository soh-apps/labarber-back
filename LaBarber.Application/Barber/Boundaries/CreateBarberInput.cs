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
        public int UserId { get; private set; }

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
        }

        public CreateBarberInput(string username, string email, string password, string name, string city, string state,
         string street, string number, string complement, string zipCode, bool commissioned)
        {
            Username = username;
            Email = email;
            Password = password;
            Name = name;
            City = city;
            State = state;
            Street = street;
            Number = number;
            Complement = complement;
            Commissioned = commissioned;
            ZipCode = zipCode;
        }

        public void SetUserId (int userId)
        {
            UserId = userId;
        }
    }
}
