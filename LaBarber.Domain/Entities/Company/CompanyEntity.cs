using LaBarber.Domain.Entities.SigningPlan;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Company
{
    [Table("Company")]
    public class CompanyEntity
    {
        public CompanyEntity()
        {
            Id = 0;
            SigningPlanId = 0;
            LastPayment = DateTime.Now;
            NextPayment = DateTime.Now;
            SigningPlan = new SigningPlanEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("SigningPlan")]
        [Column("SigningPlanId")]
        public int SigningPlanId { get; set; }

        public SigningPlanEntity SigningPlan { get; set; }

        [Column("LastPayment")]
        public DateTime LastPayment { get; set; }

        [Column("NextPayment")]
        public DateTime NextPayment { get; set; }
    }
}