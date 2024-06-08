namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class CreateBarberUnitManagerInput
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
        public int AdminId { get; private set; }

        public CreateBarberUnitManagerInput(string username, string email, string password, string name, string city, string state, string street, string number, string complement, string zipCode, bool commissioned, int barberUnitId)
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
            BarberUnitId = barberUnitId;
        }

        public void SetAdminId(int adminId)
        {
            AdminId = adminId;
        }
    }
}
