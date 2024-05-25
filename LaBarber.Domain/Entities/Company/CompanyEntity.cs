using LaBarber.Domain.Dtos.Company;
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
            LastPayment = DateTime.UtcNow;
            NextPayment = DateTime.UtcNow;
            SigningPlan = new SigningPlanEntity();
            Name = string.Empty;
            CNPJ = string.Empty;
        }

        public CompanyEntity(CreateCompanyDto dto)
        {
            Id = 0;
            Name = dto.Name;
            CNPJ = dto.CNPJ;
            LastPayment = dto.LastPayment;
            NextPayment = dto.NextPayment;
            SigningPlanId = dto.SigningPlanId;
            SigningPlan = new SigningPlanEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [ForeignKey("SigningPlan")]
        [Column("SigningPlanId")]
        public int SigningPlanId { get; set; }

        public virtual SigningPlanEntity SigningPlan { get; set; }

        [Column("LastPayment")]
        public DateTime LastPayment { get; set; }

        [Column("NextPayment")]
        public DateTime NextPayment { get; set; }
    }
}