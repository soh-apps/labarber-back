using System.Text.Json.Serialization;

namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class CreateBarberUnitInput : BarberUnitInput
    {
        [JsonIgnore]
        public int UserId { get; private set; }

        [JsonIgnore]
        public string UserRole { get; private set; }

        public CreateBarberUnitInput() : base()
        {
            UserId = 0;
            UserRole = string.Empty;
        }

        public CreateBarberUnitInput(string name, string city, string state, string street, string number, string complement, string zipCode, IEnumerable<AvailabilityInput>? workingHours) : base(name, city, state, street, number, complement, zipCode, workingHours)
        {
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
