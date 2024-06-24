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

        public async Task<LoginDto> LoginById(int credentialId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var credential = await (from login in context.Credential
                                    join profile in context.Profile
                                    on login.ProfileId equals profile.Id
                                    where login.Id == credentialId
                                    select new LoginDto(login.Username, profile.Name, 0, profile.Id, login.Id))
              .AsNoTracking()
              .FirstOrDefaultAsync();

            if (credential != null)
            {
                credential.UserId = await GetUserId(credential.ProfileId, credential.CredentialId, context);
                return credential;
            }
            else
            {
                return new LoginDto();
            }
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
                credential.UserId = await GetUserId(credential.ProfileId, credential.CredentialId, context);
                return credential;
            }
            else
            {
                return new LoginDto();
            }
        }

        public async Task<bool> ChangeBarberProfile(int profileId, int userId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var credentialId = await context.Barber.Where(x => x.Id == userId).AsNoTracking()
            .Select(x => x.CredentialId).FirstOrDefaultAsync();

            var credential = await context.Credential.Where(x => x.Id == credentialId).FirstOrDefaultAsync();

            if (credential != null)
            {
                credential.ProfileId = profileId;
                context.Credential.Update(credential);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private static async Task<int> GetUserId(int profileId, int credentialId, ContextBase context)
        {
            int userId = 0;
            userId = profileId switch
            {
                1 or 2 => await context.AppUser
                                        .Where(u => u.CredentialId == credentialId)
                                        .AsNoTracking()
                                        .Select(u => u.Id)
                                        .FirstOrDefaultAsync(),
                3 or 4 => await context.Barber
                                        .Where(u => u.CredentialId == credentialId)
                                        .AsNoTracking()
                                        .Select(u => u.Id)
                                        .FirstOrDefaultAsync(),
                5 => await context.Customer
                                        .Where(u => u.CredentialId == credentialId)
                                        .AsNoTracking()
                                        .Select(u => u.Id)
                                        .FirstOrDefaultAsync(),
                _ => 0,
            };
            return userId;
        }
    }
}
