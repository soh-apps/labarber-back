using LaBarber.Domain.Dtos.MonthlyPlan;
using LaBarber.Domain.Entities.Company;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.MonthlyPlan
{
    [Table("MonthlyPlan")]
    public partial class MonthlyPlanEntity 
    {
        public MonthlyPlanEntity()
        {
            Id = 0;
            Name = string.Empty;
            Description = string.Empty;
            Value = 0;
            CompanyId = 0;
            Company = null;
        }

        public MonthlyPlanEntity(MonthlyPlanDto entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
            Value = entity.Value;
            CompanyId = entity.CompanyId;
            Company = null;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }
        
        [Column("Name")]
        public string Name { get; set; }
        
        [Column("Description")]
        public string Description { get; set; }

        [Column("Value")]
        public decimal Value { get; set; }

        [ForeignKey("Company")]
        [Column("CompanyId")]
        public int CompanyId { get; set; }

        public virtual CompanyEntity? Company { get; set; }
    }
}