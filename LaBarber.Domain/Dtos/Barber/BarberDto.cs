using LaBarber.Domain.Entities.Barber;

namespace LaBarber.Domain.Dtos.Barber
{
    public class BarberDto
    {
        public int Id { get; set; }
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

        public BarberDto()
        {
            Id = 0;
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            ZipCode = string.Empty;
            Commissioned = false;
            BarberUnitId = 0;
            CredentialId = 0;
        }

        public BarberDto(BarberEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            City = entity.City;
            State = entity.State;
            Street = entity.Street;
            Number = entity.Number;
            Complement = entity.Complement;
            ZipCode = entity.ZipCode;
            Commissioned = entity.Commissioned;
            BarberUnitId = entity.BarberUnitId;
            CredentialId = entity.CredentialId;
        }
    }
}
