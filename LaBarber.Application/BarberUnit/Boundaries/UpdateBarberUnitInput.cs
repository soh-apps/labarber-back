﻿namespace LaBarber.Application.BarberUnit.Boundaries
{
    public class UpdateBarberUnitInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public int UserId { get; private set; }
        public string UserRole { get; private set; }
        public IEnumerable<AvailabilityInput> WorkingHours { get; set; }

        public UpdateBarberUnitInput()
        {
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            ZipCode = string.Empty;
            UserId = 0;
            UserRole = string.Empty;
            WorkingHours = new List<AvailabilityInput>();
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
