using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.Barber.Boundaries
{
    public class BarberInput
    {
        [SwaggerSchema(
            Title = "Name",
            Description = "nome do barbeiro",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "City",
            Description = "Cidade do barbeiro",
            Format = "string")]
        public string City { get; set; }

        [SwaggerSchema(
            Title = "State",
            Description = "Estado do barbeiro",
            Format = "string")]
        public string State { get; set; }

        [SwaggerSchema(
            Title = "Street",
            Description = "Rua do barbeiro",
            Format = "string")]
        public string Street { get; set; }

        [SwaggerSchema(
            Title = "Number",
            Description = "Numero da casa do barbeiro",
            Format = "string")]
        public string Number { get; set; }

        [SwaggerSchema(
            Title = "Complement",
            Description = "Complemento do endereço do barbeiro",
            Format = "string")]
        public string Complement { get; set; }

        [SwaggerSchema(
            Title = "ZipCode",
            Description = "Cep do barbeiro",
            Format = "string")]
        public string ZipCode { get; set; }

        [SwaggerSchema(
            Title = "Phone",
            Description = "Telefone do barbeiro",
            Format = "9911112222")]
        public string Phone { get; set; }

        [SwaggerSchema(
            Title = "Cellphone",
            Description = "Celular do barbeiro",
            Format = "99911112222")]
        public string Cellphone { get; set; }

        [SwaggerSchema(
            Title = "Commissioned",
            Description = "Se o Barbeiro é comissionado ou não",
            Format = "bool")]
        public bool Commissioned { get; set; }

        [SwaggerSchema(
            Title = "BarberUnitId",
            Description = "Id da barbeiaria",
            Format = "int")]
        public int BarberUnitId { get; set; }

        [SwaggerSchema(
            Title = "Commissioned",
            Description = "Se o Barbeiro é gerente ou não",
            Format = "bool")]
        public bool IsManager { get; set; }

        public int UserId { get; private set; }
        public string UserRole { get; private set; }

        public void SetUserRole(string userRole)
        {
            UserRole = userRole;
        }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }

        public BarberInput()
        {
            Name = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            ZipCode = string.Empty;
            Phone = string.Empty;
            Cellphone = string.Empty;
            Commissioned = false;
            BarberUnitId = 0;
            UserId = 0;
            IsManager = false;
            UserRole = string.Empty;
        }
    }
}