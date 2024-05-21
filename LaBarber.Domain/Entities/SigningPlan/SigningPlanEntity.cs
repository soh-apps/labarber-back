using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Enums;

namespace LaBarber.Domain.Entities.SigningPlan
{
    [Table("SigningPlan")]
    public class SigningPlanEntity
    {
        public SigningPlanEntity()
        {
            Id = 0;
            Name = string.Empty;
            Value = 0;
            PaymentType = PaymentType.None;
            BarberLimit = 0;
            BarberUnitLimit = 0;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Value")]
        public decimal Value { get; set; }

        //O que seria isso?? Recurrence????
        [Column("PaymentType")]
        public PaymentType PaymentType { get; set; }

        [Column("BarberUnitLimit")]
        public int BarberUnitLimit { get; set; }

        [Column("BarberLimit")]
        public int BarberLimit { get; set; }

        public ICollection<CompanyEntity> Companies { get; set; }
    }
}