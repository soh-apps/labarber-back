using LaBarber.Domain.Entities.Appointment;
using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.MonthlyPlan;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Customer
{
    [Table("Customer")]
    public class CustomerEntity
    {
        public CustomerEntity()
        {
            Id = 0;
            Name = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            MonthlyPayer = false;
            Status = CustomerStatus.Inactive;
            MonthlyValue = null;
            NextPayment = null;
            LastPayment = null;
            MonthlyPlanId = null;
            MonthlyPlan = null;
            CompanyId = 0;
            Company = new CompanyEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("MonthlyPayer")]
        public bool MonthlyPayer { get; set; }

        [Column("MonthlyValue")]
        public decimal? MonthlyValue { get; set; }

        [Column("Status")]
        public CustomerStatus Status { get; set; }

        [ForeignKey("MonthlyPlan")]
        [Column("MonthlyPlanId")]
        public int? MonthlyPlanId { get; set; }

        public MonthlyPlanEntity? MonthlyPlan { get; set; }

        [ForeignKey("Company")]
        [Column("CompanyId")]
        public int CompanyId { get; set; }

        public CompanyEntity Company { get; set; }

        [Column("NextPayment")]
        public DateTime? NextPayment { get; set; }

        [Column("LastPayment")]
        public DateTime? LastPayment { get; set; }
    }
}