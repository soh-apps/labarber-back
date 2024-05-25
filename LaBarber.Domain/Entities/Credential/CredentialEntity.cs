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
            Profile = new ProfileEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [ForeignKey("Profile")]
        [Column("ProfileId")]
        public int ProfileId { get; set; }

        public virtual ProfileEntity Profile { get; set; }
    }
}
