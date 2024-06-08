namespace LaBarber.Domain.Dtos.BarberUnit
{
    public class CreateBarberUnitManagerDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public bool Commissioned { get; set; }
        public int BarberUnitId { get; set; }
        public int CredentialId { get; set; }

        public CreateBarberUnitManagerDto(string name, string city, string state, string street, string number, string complement, string zipCode, bool commissioned, int barberUnitId, int credentialId)
        {
            Name = name;
            City = city;
            State = state;
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            Commissioned = commissioned;
            BarberUnitId = barberUnitId;
            CredentialId = credentialId;
        }
    }
}
