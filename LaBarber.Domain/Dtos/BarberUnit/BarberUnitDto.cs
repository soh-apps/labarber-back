using LaBarber.Domain.Entities.Barber;

namespace LaBarber.Domain.Dtos.BarberUnit
{
    public class BarberUnitDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public int CompanyId { get; set; }
        public BarberUnitStatus Status { get; set; }

        public BarberUnitDto(int id, string name, string city, string state, string street, string number, string complement, string zipCode, int companyId, BarberUnitStatus status)
        {
            Id = id;
            Name = name;
            City = city;
            State = state;
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            CompanyId = companyId;
            Status = status;
        }
    }
}
