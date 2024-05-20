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
            LatPayment = DateTime.Now;
            NextPayment = DateTime.Now;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("SigningPlan")]
        [Column("SigningPlanId")]
        public int SigningPlanId { get; set; }

        [Column("LastPayment")]
        public DateTime LatPayment { get; set; }

        [Column("NextPayment")]
        public DateTime NextPayment { get; set; }
    }
}