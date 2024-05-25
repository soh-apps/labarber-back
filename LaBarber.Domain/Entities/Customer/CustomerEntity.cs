using LaBarber.Domain.Entities.Appointment;
using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.Credential;
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
            CredentialId = 0;
            Credential = new CredentialEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

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

        public virtual MonthlyPlanEntity? MonthlyPlan { get; set; }

        [ForeignKey("Company")]
        [Column("CompanyId")]
        public int CompanyId { get; set; }

        public virtual CompanyEntity Company { get; set; }

        [Column("NextPayment")]
        public DateTime? NextPayment { get; set; }

        [Column("LastPayment")]
        public DateTime? LastPayment { get; set; }


        [ForeignKey("Credential")]
        [Column("CredentialId")]
        public int CredentialId { get; set; }

        public CredentialEntity Credential { get; set; }
    }
}