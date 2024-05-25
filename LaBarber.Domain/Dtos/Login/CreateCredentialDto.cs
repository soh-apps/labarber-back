using LaBarber.Domain.Enums;

namespace LaBarber.Domain.Dtos.Login
{
    public class CreateCredentialDto
    {
        public CreateCredentialDto()
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            Profile = UserType.Customer;
        }

        public CreateCredentialDto(string userName, string password, string email, UserType profile)
        {
            Username = userName;
            Password = password;
            Email = email;
            Profile = profile;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType Profile { get; set; }
    }
}