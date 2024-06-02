using LaBarber.Domain.Enums;

namespace LaBarber.Application.Login.Boundaries
{
    public class LoginOutput
    {
        public LoginOutput(string token, string refreshToken, int userType, string name, int credentialId)
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
            UserType = 0;
            Name = string.Empty;
            CredentialId = 0;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int UserType { get; set; }
        public int CredentialId { get; set; }
        public string Name { get; set; }
    }
}
