using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.Credential;
using LaBarber.Domain.Entities.Profile;
using Microsoft.EntityFrameworkCore;
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
            Status = UserStatus.Inactive;
            RegisterDate = DateTime.Now;
            CompanyId = null;
            Company = null;
            CredentialId = 0;
            Credential = new CredentialEntity();
        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Status")]
        public UserStatus Status { get; set; }

        [Column("RegisterDate")]
        public DateTime RegisterDate { get; set; }

        [ForeignKey("Company")]
        [Column("CompanyId")]
        public int? CompanyId { get; set; }

        public virtual CompanyEntity? Company { get; set; }

        [ForeignKey("Credential")]
        [Column("CredentialId")]
        public int CredentialId { get; set; }

        public CredentialEntity Credential { get; set; }
    }
}
