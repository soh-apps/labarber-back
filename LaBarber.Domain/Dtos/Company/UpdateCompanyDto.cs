namespace LaBarber.Domain.Dtos.Company
{
    public class UpdateCompanyDto
    {
        public UpdateCompanyDto()
        {
            CompanyId = 0;
            Name = string.Empty;
            CNPJ = string.Empty;
        }

        public UpdateCompanyDto(int companyId, string name, string cNPJ)
        {
            CompanyId = companyId;
            Name = name;
            CNPJ = cNPJ;
        }


        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
    }
}