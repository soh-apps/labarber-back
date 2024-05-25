using LaBarber.Domain.Enums;

namespace LaBarber.Domain.Dtos.AppUser
{
    public class CreateAppUserDto
    {

        public CreateAppUserDto()
        {
            Name = string.Empty;
            Status = UserStatus.Inactive;
            RegisterDate = DateTime.UtcNow;
            CompanyId = 0;
            CredentialId = 0;
        }
        
        public CreateAppUserDto(string name, UserStatus status, DateTime registerDate, int? companyId, int credentialId)
        {
            Name = name;
            Status = status;
            RegisterDate = registerDate;
            CompanyId = companyId;
            CredentialId = credentialId;
        }

        public string Name { get; set; }
        public UserStatus Status { get; set; }

        public DateTime RegisterDate { get; set; }
        public int? CompanyId { get; set; }

        public int CredentialId { get; set; }
    }
}