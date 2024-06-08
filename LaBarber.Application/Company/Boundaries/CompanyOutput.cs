using LaBarber.Domain.Dtos.Company;

namespace LaBarber.Application.Company.Boundaries
{
    public class CompanyOutput
    {
        public CompanyOutput()
        {
            Id = 0;
            SigningPlanId = 0;
            LastPayment = DateTime.UtcNow;
            NextPayment = DateTime.UtcNow;
            Name = string.Empty;
            CNPJ = string.Empty;
            PlanName = string.Empty;
        }

        public CompanyOutput(CompanyDto dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            CNPJ = dto.CNPJ;
            LastPayment = dto.LastPayment;
            NextPayment = dto.NextPayment;
            SigningPlanId = dto.SigningPlanId;
            PlanName = dto.PlanName;
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