using LaBarber.Domain.Enums;

namespace LaBarber.Application.Login.Boundaries
{
    public class LoginOutput
    {
        public LoginOutput(string token, string refreshToken, UserType userType, string name, int credentialId)
        {
            Token = token;
            RefreshToken = refreshToken;
            UserType = userType;
            Name = name;
            CredentialId = credentialId;
        }

        public LoginOutput()
        {
            Token = string.Empty;
            RefreshToken = string.Empty;
            UserType = UserType.Customer;
            Name = string.Empty;
            CredentialId = 0;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserType UserType { get; set; }
        public int CredentialId { get; set; }
        public string Name { get; set; }
    }
}
