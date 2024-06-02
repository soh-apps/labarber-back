using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.AppUser;
using LaBarber.Domain.Entities.AppUser;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.AppUser
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

        public async Task CreateAppUser(CreateAppUserDto dto)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var user = new AppUserEntity(dto);

            await context.AppUser.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<GetAppUserDto> GetById(int id)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var result = await context.AppUser.FindAsync(id);
            if (result == null)
            {
                return await Task.FromResult<GetAppUserDto>(null);
            }
            return new GetAppUserDto(result);
        }
    }
}