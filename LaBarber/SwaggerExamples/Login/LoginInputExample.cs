using LaBarber.Application.Login.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Login
{
    public class LoginInputExample : IExamplesProvider<LoginInput>
    {
        public LoginInput GetExamples()
        {
            return new LoginInput
            {
                Username = "teste",
                Password = "123qwe"
            };
        }
    }
}