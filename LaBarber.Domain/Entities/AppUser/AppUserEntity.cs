using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.Profile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBarber.Domain.Entities.AppUser
{
    [Table("AppUser")]
    public class AppUserEntity
    {
        public AppUserEntity()
        {
            Id = 0;
            Name = string.Empty;
            Password = string.Empty;
            Status = UserStatus.Inactive;
            RegisterDate = DateTime.Now;
            ProfileId = 0;
            Profile = new ProfileEntity();
            CompanyId = null;
            Company = null;
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Status")]
        public UserStatus Status { get; set; }

        [Column("RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [ForeignKey("Profile")]
        [Column("ProfileId")]
        public int ProfileId { get; set; }

        public virtual ProfileEntity Profile { get; set; }

        [ForeignKey("Company")]
        [Column("CompanyId")]
        public int? CompanyId { get; set; }

        public virtual CompanyEntity? Company { get; set; }
    }
}
