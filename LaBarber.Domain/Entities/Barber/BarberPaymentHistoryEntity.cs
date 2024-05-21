using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Barber
{
    public class BarberPaymentHistoryEntity
    {
        public BarberPaymentHistoryEntity()
        {
            Id = 0;
            PaymentDate = DateTime.Now;
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

        public BarberEntity Barber { get; set; }

        [ForeignKey("BarberUnit")]
        [Column("BarberUnitId")]
        public int BarberUnitId { get; set; }

        public BarberUnitEntity BarberUnit { get; set; }
    }
}
