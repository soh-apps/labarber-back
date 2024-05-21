using LaBarber.Domain.Entities.Appointment;
using LaBarber.Domain.Entities.AppUser;
using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.Service;
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
            State = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            ZipCode = string.Empty;
            Name = string.Empty;
            CompanyId = 0;
            Status = BarberUnitStatus.Inactive;
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

        public CompanyEntity Company { get; set; }

        [Column("Status")]
        public BarberUnitStatus Status { get; set; }

        public ICollection<BarberUnitAvailability> Availabilities { get; set; }

        public ICollection<ServiceEntity> Services { get; set; }

        public ICollection<BarberEntity> Barbers { get; set; }

        public ICollection<AppointmentEntity> Appointments { get; set; }

        public ICollection<AppUserEntity> Users { get; set; }
    }
}
