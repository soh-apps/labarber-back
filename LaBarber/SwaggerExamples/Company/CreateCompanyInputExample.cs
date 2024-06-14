using LaBarber.Application.Company.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Company
{
    public class CreateCompanyInputExample : IExamplesProvider<CreateCompanyInput>
    {
        public CreateCompanyInput GetExamples()
        {
            return new CreateCompanyInput(1,"Teste","16672393000110");
        }
    }
}