using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.Profile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.Credential
{
    [Table("Credential")]
    public class CredentialEntity
    {
        public CredentialEntity()
        {
            Id = 0;
            Username = string.Empty;
            Password = string.Empty;
            ProfileId = 0;
            Profile =  null;
            ChangedPassword = false;
            ChangePasswordCode = string.Empty;
            Email = string.Empty;
        }

        public CredentialEntity(int id, string username, string password, int profileId, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            ProfileId = profileId;
            Profile =  null;
            ChangedPassword = false;
            ChangePasswordCode = string.Empty;
            Email = email;
        }

        public CredentialEntity(CreateCredentialDto dto)
        {
            Username = dto.Username;
            Password = dto.Password;
            ChangePasswordCode = string.Empty;
            ProfileId = Convert.ToInt32(dto.Profile);
            Email = dto.Email;
            ChangedPassword = false;
            Profile = null;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("ChangePasswordCode")]
        public string ChangePasswordCode { get; set; }

        [Column("ChangedPassword")]
        public bool ChangedPassword { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [ForeignKey("Profile")]
        [Column("ProfileId")]
        public int ProfileId { get; set; }

        public virtual ProfileEntity? Profile { get; set; }
    }
}
