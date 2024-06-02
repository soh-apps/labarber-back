using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using LaBarber.Domain.Configuration;
using LaBarber.Domain.Entities.Credential;

namespace LaBarber.Infra.Repository.Credential
{
        public class LoggedUserRepository : ILoggedUserRepository
    {
        private readonly IDynamoDBContext _dynamoDBContext;

        public LoggedUserRepository(IAmazonDynamoDB client, DynamoLocalOptions options)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (!string.IsNullOrEmpty(env) && env == "Development")
            {
                AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig
                {
                    ServiceURL = options.ServiceUrl
                };
                AmazonDynamoDBClient dynamoClient = new AmazonDynamoDBClient("Aksdjaksdhueiadqwert", "dshdajksdhajskdhasjkdhasjkdashkjqwertyu", clientConfig);
                _dynamoDBContext = new DynamoDBContext(dynamoClient);
            }
            else
            {
                _dynamoDBContext = new DynamoDBContext(client);
            }
        }

        public async Task SaveUserRefreshToken(int credentialId, string refreshToken)
        {
            var entity = new LoggedUserEntity(credentialId.ToString(), refreshToken);
            await _dynamoDBContext.SaveAsync(entity);
        }

        public async Task<bool> RefreshTokenExists(int credentialId, string refreshToken)
        {
            var entity = await _dynamoDBContext.LoadAsync<LoggedUserEntity>(credentialId.ToString());
            if(entity != null)
            {
                return entity.RefreshToken.Equals(refreshToken);
            }
            return false;
        }
    }
}