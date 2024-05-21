using LaBarber.Domain.Entities.Customer;
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
            Description = string.Empty;
            Value = 0;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }
        
        [Column("Description")]
        public string Description { get; set; }

        [Column("Value")]
        public decimal Value { get; set; }

        public ICollection<CustomerEntity> Customers { get; set; }
    }
}