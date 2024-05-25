using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.Credential;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.Credential
{
    public class CredentialRepository : ICredentialRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        private readonly IOptions<Secrets> _secrets;

        public CredentialRepository(IOptions<Secrets> secrets)
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
            _secrets = secrets;
        }
        public async Task<LoginDto> Login(string username, string pwd)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var credential = await (from login in context.Credential
                          join profile in context.Profile
                          on login.ProfileId equals profile.Id
                          where login.Username == username && login.Password == pwd
                          select new LoginDto(login.Username, profile.Name, 0, profile.Id, login.Id))
                          .AsNoTracking()
                          .FirstOrDefaultAsync();

            if (credential != null)
            {
                switch (credential.ProfileId)
                {
                    case 1:
                    case 2:
                    case 3:
                        credential.UserId = await context.AppUser
                            .Where(u => u.CredentialId == credential.CredentialId)
                            .AsNoTracking()
                            .Select(u => u.Id)
                            .FirstOrDefaultAsync();
                        break;

                    case 4:
                        credential.UserId = await context.Barber
                            .Where(u => u.CredentialId == credential.CredentialId)
                            .AsNoTracking()
                            .Select(u => u.Id)
                            .FirstOrDefaultAsync();
                        break;

                    case 5:
                        credential.UserId = await context.Customer
                            .Where(u => u.CredentialId == credential.CredentialId)
                            .AsNoTracking()
                            .Select(u => u.Id)
                            .FirstOrDefaultAsync();
                        break;

                    default:
                        credential.UserId = 0;
                        break;
                }
                return credential;
            }
            else
            {
                return new LoginDto();
            }
        }
    }
}
