using LaBarber.Domain.Entities.Appointment;
using LaBarber.Domain.Entities.Profile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Barber
{
    [Table("Barber")]
    public class BarberEntity
    {
        public BarberEntity()
        {
            Id = 0;
            Name = string.Empty;
            Password = string.Empty;
            City = string.Empty;
            State = string.Empty;
            Street = string.Empty;
            ZipCode = string.Empty;
            Status = 0;
            RegisterDate = DateTime.Now;
            ProfileId = 0;
            Profile = new ProfileEntity();
            BarberUnitId = 0;
            BarberUnit = new BarberUnitEntity();
            Commissioned = false;
            LastPayment = DateTime.Now;
            NextPayment = DateTime.Now;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("State")]
        public string State { get; set; }

        [Column("Street")]
        public string Street { get; set; }

        [Column("ZipCode")]
        public string ZipCode { get; set; }

        [Column("Status")]
        public BarberStatus Status { get; set; }

        [Column("RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [Column("ProfileId")]
        public int ProfileId { get; set; }

        public ProfileEntity Profile { get; set; }

        [Column("BarberUnitId")]
        public int BarberUnitId { get; set; }

        public BarberUnitEntity BarberUnit { get; set; }

        [Column("Commissioned")]
        public bool Commissioned { get; set; }

        [Column("LastPayment")]
        public DateTime? LastPayment { get; set; }

        [Column("NextPayment")]
        public DateTime? NextPayment { get; set; }
    }
}
