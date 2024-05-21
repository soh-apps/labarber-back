using LaBarber.Domain.Entities.Barber;
using LaBarber.Domain.Entities.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Customer
{
    [Table("CustomerPaymentHistory")]
    public class CustomerPaymentHistoryEntity
    {
        public CustomerPaymentHistoryEntity()
        {
            Id = 0;
            PaymentDate = DateTime.Now;
            PaymentValue = 0;
            BarberId = 0;
            Barber = new BarberEntity();
            BarberUnitId = 0;
            BarberUnit = new BarberUnitEntity();
            CustomerId = 0;
            Customer = new CustomerEntity();
            ServiceId = null;
            Service = null;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("PaymentDate")]
        public DateTime PaymentDate { get; set; }

        [Column("PaymentValue")]
        public decimal PaymentValue { get; set; }

        [ForeignKey("Customer")]
        [Column("CustomerId")]
        public int CustomerId { get; set; }

        public virtual CustomerEntity Customer { get; set; }

        [ForeignKey("Barber")]
        [Column("BarberId")]
        public int BarberId { get; set; }

        public virtual BarberEntity Barber { get; set; }

        [ForeignKey("BarberUnit")]
        [Column("BarberUnitId")]
        public int BarberUnitId { get; set; }

        public virtual BarberUnitEntity BarberUnit { get; set; }

        [ForeignKey("Service")]
        [Column("ServiceId")]
        public int? ServiceId { get; set; }

        public virtual ServiceEntity? Service { get; set; }
    }
}
