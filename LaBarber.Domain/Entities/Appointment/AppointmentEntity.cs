using LaBarber.Domain.Entities.Barber;
using LaBarber.Domain.Entities.BarberUnit;
using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.Customer;
using LaBarber.Domain.Entities.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Appointment
{
    [Table("Appointment")]
    public class AppointmentEntity
    {
        public AppointmentEntity()
        {
            Id = 0;
            CustomerName = string.Empty;
            StartAppointmentDate = DateTime.UtcNow;
            EndAppointmentDate = DateTime.UtcNow;
            Value = 0;
            IsCommissioned = false;
            CommissionValue = null;
            Status = AppointmentStatus.New;
            PaymentMethod = null;
            AdditionalInfo = null;
            CustomerId = null;
            Customer = null;
            CompanyId = 0;
            Company = null;
            BarberId = 0;
            Barber = null;
            BarberUnitId = 0;
            BarberUnit = null;
            ServiceId = 0;
            Service = null;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("CustomerName")]
        public string CustomerName { get; set; }

        [Column("StartAppointmentDate")]
        public DateTime StartAppointmentDate { get; set; }

        [Column("EndAppointmentDate")]
        public DateTime EndAppointmentDate { get; set; }

        [Column("Value")]
        public decimal Value { get; set; }

        [Column("IsCommissioned")]
        public bool IsCommissioned { get; set; }

        [Column("CommissionValue")]
        public decimal? CommissionValue { get; set; }

        [Column("Status")]
        public AppointmentStatus Status { get; set; }

        [Column("PaymentMethod")]
        public PaymentMethod? PaymentMethod { get; set; }

        [Column("AdditionalInfo")]
        public string? AdditionalInfo { get; set; }

        [ForeignKey("Customer")]
        [Column("CustomerId")]
        public int? CustomerId { get; set; }

        public virtual CustomerEntity? Customer { get; set; }

        [ForeignKey("Company")]
        [Column("CompanyId")]
        public int CompanyId { get; set; }

        public virtual CompanyEntity? Company { get; set; }

        [ForeignKey("BarberUnit")]
        [Column("BarberUnitId")]
        public int BarberUnitId { get; set; }

        public virtual BarberUnitEntity? BarberUnit { get; set; }

        [ForeignKey("Service")]
        [Column("ServiceId")]
        public int ServiceId { get; set; }

        public virtual ServiceEntity? Service { get; set; }

        [ForeignKey("Barber")]
        [Column("BarberId")]
        public int BarberId { get; set; }

        public virtual BarberEntity? Barber { get; set; }
    }
}
