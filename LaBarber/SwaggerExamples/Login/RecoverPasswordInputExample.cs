using LaBarber.Application.Login.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Login
{
    public class RecoverPasswordInputExample : IExamplesProvider<RecoverPasswordInput>
    {
        public RecoverPasswordInput GetExamples()
        {
            return new RecoverPasswordInput
            {
                Code = "123456",
                Password = "password"
            };
        }
    }
}