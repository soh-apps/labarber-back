namespace LaBarber.Application.Company.Boundaries
{
    public class CreateCompanyInput
    {
        public CreateCompanyInput()
        {
            SigningPlanId = 0;
            Name = string.Empty;
            CNPJ = string.Empty;
        }

        public int SigningPlanId { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
    }
}
