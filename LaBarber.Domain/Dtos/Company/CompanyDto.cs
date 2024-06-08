using LaBarber.Domain.Entities.Company;

namespace LaBarber.Domain.Dtos.Company
{
    public class CompanyDto
    {
        public CompanyDto()
        {
            Id = 0;
            SigningPlanId = 0;
            LastPayment = DateTime.UtcNow;
            NextPayment = DateTime.UtcNow;
            Name = string.Empty;
            CNPJ = string.Empty;
            PlanName = string.Empty;
        }

        public CompanyDto(CompanyEntity entity, string planName)
        {
            Id = entity.Id;
            Name = entity.Name;
            CNPJ = entity.CNPJ;
            LastPayment = entity.LastPayment;
            NextPayment = entity.NextPayment;
            SigningPlanId = entity.SigningPlanId;
            PlanName = planName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public int SigningPlanId { get; set; }
        public string PlanName { get; set; }
        public DateTime LastPayment { get; set; }
        public DateTime NextPayment { get; set; }
    }
}