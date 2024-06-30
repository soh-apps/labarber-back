using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class BarberUnitInput
    {
        [SwaggerSchema(
            Title = "Name",
            Description = "Preencha com o nome da barbearia",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "City",
            Description = "Preencha com a cidade em que a barbearia está localizada",
            Format = "string")]
        public string City { get; set; }

        [SwaggerSchema(
            Title = "State",
            Description = "Preencha com a sigla do estado em que a barbearia está localizada",
            Format = "string")]
        public string State { get; set; }

        [SwaggerSchema(
            Title = "Street",
            Description = "Preencha com a rua em que a barbearia está localizada",
            Format = "string")]
        public string Street { get; set; }

        [SwaggerSchema(
            Title = "Number",
            Description = "Preencha com o número na rua em que a barbearia está localizada",
            Format = "string")]
        public string Number { get; set; }

        [SwaggerSchema(
            Title = "Complement",
            Description = "Preencha com o complemento da barbearia (se houver)",
            Format = "string")]
        public string Complement { get; set; }

        [SwaggerSchema(
            Title = "ZipCode",
            Description = "Preencha com o CEP em que a barbearia está localizada",
            Format = "string")]
        public string ZipCode { get; set; }

        [SwaggerSchema(
            Title = "WorkingHours",
            Description = "Preencha com o horário de atendimento da barbearia",
            Format = "string")]
        public IEnumerable<AvailabilityInput>? WorkingHours { get; set; }

        public BarberUnitInput()
        {
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            ZipCode = string.Empty;
            WorkingHours = new List<AvailabilityInput>();
        }

        public BarberUnitInput(string name, string city, string state, string street, string number, string complement, string zipCode, IEnumerable<AvailabilityInput>? workingHours)
        {
            Name = name;
            City = city;
            State = state;
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            WorkingHours = workingHours;
        }
    }
}
