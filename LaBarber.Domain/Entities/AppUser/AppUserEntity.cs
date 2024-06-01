using LaBarber.Domain.Dtos.AppUser;
using LaBarber.Domain.Entities.Company;
using LaBarber.Domain.Entities.Credential;
using LaBarber.Domain.Enums;
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
            RegisterDate = DateTime.UtcNow;
            CompanyId = null;
            Company = null;
            CredentialId = 0;
            Credential = null;
        }
        public AppUserEntity(int id, string name, int? companyId, int credentialId)
        {
            Id = id;
            Name = name;
            Status = UserStatus.Active;
            RegisterDate = DateTime.UtcNow;
            CompanyId = companyId;
            Company = null;
            CredentialId = credentialId;
            Credential = null;
        }

        public AppUserEntity(CreateAppUserDto dto)
        {
            Name = dto.Name;
            Status = dto.Status;
            RegisterDate = dto.RegisterDate;
            CompanyId = dto.CompanyId;
            CredentialId = dto.CredentialId;
            Credential = null;
            Company = null;
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

        public virtual CredentialEntity? Credential { get; set; }
    }
}
