namespace LaBarber.Application.Company.Boundaries
{
    public class UpdateCompanyInput
    {
        public UpdateCompanyInput()
        {
            Name = string.Empty;
            CompanyId = 0;
            CNPJ = string.Empty;
            UserId = 0;
        }

        public int UserId { get; private set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }

        public void SetUserId(int userId)
        {
            UserId = userId;
        }
    }
}