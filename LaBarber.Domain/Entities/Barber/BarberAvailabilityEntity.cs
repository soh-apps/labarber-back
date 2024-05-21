using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LaBarber.Domain.Entities.Barber
{
    [Table("BarberAvailability")]
    public class BarberAvailabilityEntity
    {
        public BarberAvailabilityEntity()
        {
            Id = 0;
            WorkingDay = 0;
            StartWorkingHour = new TimeSpan(0, 0, 0);
            EndWorkingHour = new TimeSpan(0, 0, 0);
            BarberId = 0;
            Barber = new BarberEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("WorkingDay")]
        public int WorkingDay { get; set; }

        [Column("StartWorkingHour")]
        public TimeSpan StartWorkingHour { get; set; }

        [Column("EndWorkingHour")]
        public TimeSpan EndWorkingHour { get; set; }

        [ForeignKey("Barber")]
        [Column("BarberId")]
        public int BarberId { get; set; }

        public virtual BarberEntity Barber { get; set; }
    }
}
