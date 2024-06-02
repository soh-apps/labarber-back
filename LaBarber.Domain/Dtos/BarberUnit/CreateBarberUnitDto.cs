namespace LaBarber.Domain.Dtos.BarberUnit
{
    public class CreateBarberUnitDto
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public int CompanyId { get; set; }

        public CreateBarberUnitDto()
        {
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            ZipCode = string.Empty;
            CompanyId = 0;
        }

        public CreateBarberUnitDto(string name, string city, string state, string street, string number, string complement, string zipCode, int companyId)
        {
            Name = name;
            City = city;
            State = state;
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            CompanyId = companyId;
        }
    }
}
