using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.Company;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Barber
{
    [Table("BarberUnit")]
    public class BarberUnitEntity
    {
        public BarberUnitEntity()
        {
            Id = 0;
            City = string.Empty;
            Complement = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            ZipCode = string.Empty;
            Name = string.Empty;
            CompanyId = 0;
            Company = new CompanyEntity();
            Status = BarberUnitStatus.Inactive;
        }

        public BarberUnitEntity(CreateBarberUnitDto input)
        {
            Id = 0;
            City = input.City;
            Complement = input.Complement;
            State = input.State;
            Street = input.Street;
            Number = input.Number;
            ZipCode = input.ZipCode;
            Name = input.Name;
            CompanyId = input.CompanyId;
            Company = null;
            Status = BarberUnitStatus.Active;
        }
        public BarberUnitEntity(UpdateBarberUnitDto input)
        {
            Id = input.Id;
            City = input.City;
            Complement = input.Complement;
            State = input.State;
            Street = input.Street;
            Number = input.Number;
            ZipCode = input.ZipCode;
            Name = input.Name;
            CompanyId = input.CompanyId;
            Company = null;
            Status = BarberUnitStatus.Active;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("Street")]
        public string Street { get; set; }

        [Column("Number")]
        public string Number { get; set; }

        [Column("Complement")]
        public string Complement { get; set; }

        [Column("ZipCode")]
        public string ZipCode { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("CompanyId")]
        public int CompanyId { get; set; }

        public virtual CompanyEntity? Company { get; set; }

        [Column("Status")]
        public BarberUnitStatus Status { get; set; }
    }
}
