using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Barber
{
    [Table("BarberPaymentHistory")]
    public class BarberPaymentHistoryEntity
    {
        public BarberPaymentHistoryEntity()
        {
            Id = 0;
            PaymentDate = DateTime.UtcNow;
            PaymentValue = 0;
            BarberId = 0;
            Barber = new BarberEntity();
            BarberUnitId = 0;
            BarberUnit = new BarberUnitEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("PaymentDate")]
        public DateTime PaymentDate { get; set; }

        [Column("PaymentValue")]
        public decimal PaymentValue { get; set; }

        [Column("BarberId")]
        public int BarberId { get; set; }

        public virtual BarberEntity Barber { get; set; }

        [ForeignKey("BarberUnit")]
        [Column("BarberUnitId")]
        public int BarberUnitId { get; set; }

        public virtual BarberUnitEntity BarberUnit { get; set; }
    }
}
