using LaBarber.Application.Login.Boundaries;
using LaBarber.Domain.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Login
{
    public class LoginOutputExample : IExamplesProvider<LoginOutput>
    {
        public LoginOutput GetExamples()
        {
            return new LoginOutput
            {
                Token = "Token",
                RefreshToken = "RefreshToken",
                UserType = UserType.Master,
                Name = "Name",
                CredentialId = 1
            };
        }
    }
}