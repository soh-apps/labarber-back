namespace LaBarber.Domain.Dtos.Login
{
    public class LoginDto
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public int UserId { get; set; }
        public int CredentialId { get; set; }
        public int ProfileId { get; set; }

        public LoginDto()
        {
            Name = string.Empty;
            Role = string.Empty;
            UserId = 0;
            ProfileId = 0;
            CredentialId = 0;
        }

        public LoginDto(string name, string role, int userId, int profileId, int credentialId)
        {
            Name = name;
            Role = role;
            UserId = userId;
            ProfileId = profileId;
            CredentialId = credentialId;
        }
    }
}
