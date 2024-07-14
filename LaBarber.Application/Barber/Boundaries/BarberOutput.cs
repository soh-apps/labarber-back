using LaBarber.Domain.Dtos.Barber;
using LaBarber.Domain.Entities.Barber;
using LaBarber.Domain.Enums;
using LaBarber.Domain.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.Barber.Boundaries
{
    public class BarberOutput
    {
        [SwaggerSchema(
            Title = "Id",
            Description = "Id do barbeiro",
            Format = "int")]
        public int Id { get; set; }

        [SwaggerSchema(
            Title = "Name",
            Description = "Nome do barbeiro",
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
            Description = "Id da unidade",
            Format = "int")]
        public int BarberUnitId { get; set; }


        [SwaggerSchema(
            Title = "Role",
            Description = "Perfil do barbeiro",
            Format = "UserType")]
        public UserType Role { get; set; }

        [SwaggerSchema(
            Title = "Status",
            Description = "Status do barbeiro",
            Format = "BarberStatus")]
        public BarberStatus Status { get; set; }

        public BarberOutput()
        {
            Id = 0;
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
            Status = BarberStatus.Inactive;
        }

        public BarberOutput(BarberDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            City = dto.City;
            State = dto.State;
            Street = dto.Street;
            Number = dto.Number;
            Complement = dto.Complement;
            ZipCode = dto.ZipCode;
            Phone = dto.Phone.FormatPhone();
            Cellphone = dto.Cellphone.FormatCellphone();
            Commissioned = dto.Commissioned;
            BarberUnitId = dto.BarberUnitId;
            Role = dto.Role;
            Status = dto.Status;
        }
    }
}