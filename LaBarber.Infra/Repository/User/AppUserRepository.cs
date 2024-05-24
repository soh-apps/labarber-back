using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.AppUser;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.User
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        private readonly IOptions<Secrets> _secrets;

        public AppUserRepository(IOptions<Secrets> secrets)
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
            _secrets = secrets;
        }
        public async Task<LoginDto> LoginAppUser(string username, string pwd)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            return await (from user in context.AppUser
                          join profile in context.Profile
                          on user.ProfileId equals profile.Id
                          select new LoginDto(user.Name, profile.Name, user.Id))
                          .AsNoTracking()
                          .FirstOrDefaultAsync();
        }
    }
}
