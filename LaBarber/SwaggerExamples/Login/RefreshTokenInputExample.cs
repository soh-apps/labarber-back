using LaBarber.Application.Login.Boundaries;
using Swashbuckle.AspNetCore.Filters;

namespace LaBarber.API.SwaggerExamples.Login
{
    public class RefreshTokenInputExample : IExamplesProvider<RefreshTokenInput>
    {
        public RefreshTokenInput GetExamples()
        {
            return new RefreshTokenInput
            {
                CredentialId = 1,
                RefreshToken = "refreshToken"
            };
        }
    }
}