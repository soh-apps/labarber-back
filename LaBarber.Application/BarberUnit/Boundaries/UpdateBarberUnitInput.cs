using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class UpdateBarberUnitInput : BarberUnitInput
    {

        [SwaggerSchema(
            Title = "Id",
            Description = "Preencha com o id da barbearia",
            Format = "int")]
        public int Id { get; set; }

        [JsonIgnore]
        public int UserId { get; private set; }

        [JsonIgnore]
        public string UserRole { get; private set; }

        public UpdateBarberUnitInput() : base()
        {
            UserId = 0;
            UserRole = string.Empty;
        }
        public UpdateBarberUnitInput(int id, string name, string city, string state, string street, string number, string complement, string zipCode, IEnumerable<AvailabilityInput>? workingHours) : base(name, city, state, street, number, complement, zipCode, workingHours)
        {
            Id = id;
            UserId = 0;
            UserRole = string.Empty;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public void SetUserRole(string role)
        {
            UserRole = role;
        }
    }
}
