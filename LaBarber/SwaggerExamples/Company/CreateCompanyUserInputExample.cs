using LaBarber.Application.Company.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Company
{
    public class CreateCompanyUserInputExample : IExamplesProvider<CreateCompanyUserInput>
    {
        public CreateCompanyUserInput GetExamples()
        {
            return new CreateCompanyUserInput
            {
                Name = "AdminTeste",
                UserName = "loginTeste",
                CompanyId = 1,
                Email = "teste@teste.com",
                Password = "qwe123"
            };
        }
    }
}