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

        public async Task<bool> AddPasswordRecoveryCode(int id, string code)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var credential = await context.Credential.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (credential != null)
            {
                credential.ChangePasswordCode = code;
                context.Update(credential);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ChangePassword(int credentialId, string password)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var credential = await context.Credential.Where(x => x.Id == credentialId).FirstOrDefaultAsync();
            if (credential != null)
            {
                credential.Password = password;
                credential.ChangedPassword = true;
                credential.ChangePasswordCode = string.Empty;
                context.Update(credential);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> CreateCredential(CreateCredentialDto dto)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var credential = new CredentialEntity(dto);

            await context.Credential.AddAsync(credential);
            await context.SaveChangesAsync();

            return credential.Id;
        }

        public async Task<bool> CredentialExists(string username, string email)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            return await context.Credential.Where(x => x.Username == username || x.Email == email).AnyAsync();
        }

        public async Task DeleteCredential(int id)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var credential = await context.Credential.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (credential != null)
            {
                context.Credential.Remove(credential);
                await context.SaveChangesAsync();
            }
        }

        public async Task<CredentialDto> GetCredentialBycode(string code)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var credential = await context.Credential.Where(x => x.ChangePasswordCode == code).Select(x => new CredentialDto(x)).AsNoTracking().FirstOrDefaultAsync();
            if (credential != null)
            {
                return credential;
            }
            return new CredentialDto();
        }

        public async Task<CredentialDto> GetCredentialByEmail(string email)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var credential = await context.Credential.Where(x => x.Email == email).Select(x => new CredentialDto(x)).AsNoTracking().FirstOrDefaultAsync();
            if (credential != null)
            {
                return credential;
            }
            return new CredentialDto();
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
                        credential.UserId = await context.AppUser
                            .Where(u => u.CredentialId == credential.CredentialId)
                            .AsNoTracking()
                            .Select(u => u.Id)
                            .FirstOrDefaultAsync();
                        break;

                    case 3:
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
