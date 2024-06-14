using LaBarber.Application.Login.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Login
{
    public class ForgotPasswordInputExample : IExamplesProvider<ForgotPasswordInput>
    {
        public ForgotPasswordInput GetExamples()
        {
            return new ForgotPasswordInput
            {
                Email = "teste@teste.com.br"
            };
        }
    }
}