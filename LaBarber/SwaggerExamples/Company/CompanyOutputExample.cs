using LaBarber.Application.Company.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Company
{
    public class CompanyOutputExample : IExamplesProvider<CompanyOutput>
    {
        public CompanyOutput GetExamples()
        {
            return new CompanyOutput
            {
                Id = 1,
                SigningPlanId = 1,
                LastPayment = DateTime.UtcNow,
                NextPayment = DateTime.UtcNow,
                Name = "Teste",
                CNPJ = "16672393000110",
                PlanName = "Gratuito"
            };
        }
    }
}