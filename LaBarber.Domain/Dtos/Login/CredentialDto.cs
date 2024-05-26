using LaBarber.Domain.Entities.Credential;

namespace LaBarber.Domain.Dtos.Login
{
    public class CredentialDto
    {
        public CredentialDto()
        {
            Id = 0;
            Username = string.Empty;
            Password = string.Empty;
            ProfileId = 0;
            ChangedPassword = false;
            ChangePasswordCode = string.Empty;
            Email = string.Empty;
        }

        public CredentialDto(CredentialEntity entity)
        {
            Id = entity.Id;
            Username = entity.Username;
            Password = entity.Password;
            ChangePasswordCode = entity.ChangePasswordCode;
            ProfileId = entity.ProfileId;
            Email = entity.Email;
            ChangedPassword = entity.ChangedPassword;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ChangePasswordCode { get; set; }
        public bool ChangedPassword { get; set; }
        public string Email { get; set; }
        public int ProfileId { get; set; }
    }
}