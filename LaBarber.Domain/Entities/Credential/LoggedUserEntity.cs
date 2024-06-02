using Amazon.DynamoDBv2.DataModel;

namespace LaBarber.Domain.Entities.Credential
{
    [DynamoDBTable("LaBarberLoggedUser")]
    public class LoggedUserEntity
    {
        public LoggedUserEntity(string credentialId, string refreshToken)
        {
            CredentialId = credentialId;
            RefreshToken = refreshToken;
        }

        public LoggedUserEntity()
        {
            CredentialId = string.Empty;
            RefreshToken = string.Empty;
        }

        [DynamoDBHashKey("credentialId")]
        public string CredentialId { get; set; }

        [DynamoDBProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}