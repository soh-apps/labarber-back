using LaBarber.Domain.Entities.AppUser;
using LaBarber.Domain.Enums;

namespace LaBarber.Domain.Dtos.AppUser
{
    public class GetAppUserDto
    {
        public GetAppUserDto()
        {
            Name = string.Empty;
            Status = UserStatus.Inactive;
            RegisterDate = DateTime.UtcNow;
            CompanyId = 0;
            CredentialId = 0;
        }

        public GetAppUserDto(string name, UserStatus status, DateTime registerDate, int? companyId, int credentialId)
        {
            Name = name;
            Status = status;
            RegisterDate = registerDate;
            CompanyId = companyId;
            CredentialId = credentialId;
        }

        public GetAppUserDto(AppUserEntity entity)
        {
            Name = entity.Name;
            Status = entity.Status;
            RegisterDate = entity.RegisterDate;
            CompanyId = entity.CompanyId;
            CredentialId = entity.CredentialId;
        }

        public string Name { get; set; }
        public UserStatus Status { get; set; }

        public DateTime RegisterDate { get; set; }
        public int? CompanyId { get; set; }

        public int CredentialId { get; set; }
    }
}
