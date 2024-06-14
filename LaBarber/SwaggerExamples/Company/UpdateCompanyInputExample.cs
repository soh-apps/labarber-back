using LaBarber.Application.Company.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Company
{
    public class UpdateCompanyInputExample : IExamplesProvider<UpdateCompanyInput>
    {
        public UpdateCompanyInput GetExamples()
        {
            return new UpdateCompanyInput
            {
                Name = "Teste",
                CompanyId = 1,
                CNPJ = "16672393000110",
            };
        }
    }
}