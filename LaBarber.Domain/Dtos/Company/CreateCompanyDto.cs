namespace LaBarber.Domain.Dtos.Company
{
    public class CreateCompanyDto
    {
        public CreateCompanyDto()
        {
            SigningPlanId = 0;
            Name = string.Empty;
            CNPJ = string.Empty;
            LastPayment = DateTime.UtcNow;
            NextPayment = DateTime.UtcNow;
        }

        public CreateCompanyDto(int signingPlanId, string name, string cNPJ)
        {
            SigningPlanId = signingPlanId;
            Name = name;
            CNPJ = cNPJ;
            LastPayment = DateTime.UtcNow;
            NextPayment = DateTime.UtcNow.AddMonths(1);
        }

        public int SigningPlanId { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime LastPayment { get; set; }
        public DateTime NextPayment { get; set; }
    }
}