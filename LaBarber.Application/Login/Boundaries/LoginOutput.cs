using LaBarber.Domain.Enums;

namespace LaBarber.Application.Login.Boundaries
{
    public class LoginOutput
    {
        public LoginOutput(string token, string refreshToken, UserType userType, string name)
        {
            Token = token;
            RefreshToken = refreshToken;
            UserType = userType;
            Name = name;
        }

        public LoginOutput()
        {
            Token = string.Empty;
            RefreshToken = string.Empty;
            UserType = UserType.Customer;
            Name = string.Empty;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public UserType UserType { get; set; }
        public string Name { get; set; }
    }
}
