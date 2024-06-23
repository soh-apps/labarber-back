using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.Barber;
using LaBarber.Domain.Entities.Barber;
using LaBarber.Domain.Enums;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.Barber
{
    public class BarberRepository : IBarberRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        private readonly IOptions<Secrets> _secrets;
        public BarberRepository(DbContextOptions<ContextBase> optionsBuilder, IOptions<Secrets> secrets)
        {
            _optionsBuilder = optionsBuilder;
            _secrets = secrets;
        }

        public async Task<bool> CreateBarber(CreateBarberDto input)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var barberUnit = new BarberEntity(input);
            var created = await context.Barber.AddAsync(barberUnit);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BarberDto>> GetAllBarbers(int barberUnitId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            return await (from barber in context.Barber
                          join credential in context.Credential on barber.CredentialId equals credential.Id
                          join profile in context.Profile on credential.ProfileId equals profile.Id
                          where barber.BarberUnitId == barberUnitId
                          select new BarberDto(barber, (UserType)profile.Id)).AsNoTracking().ToListAsync();
        }

        public async Task<BarberDto> GetBarberByUserId(int userId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var dto = await (from barber in context.Barber
                             join credential in context.Credential on barber.CredentialId equals credential.Id
                             join profile in context.Profile on credential.ProfileId equals profile.Id
                             where barber.Id == userId
                             select new BarberDto(barber, (UserType)profile.Id)).AsNoTracking().FirstOrDefaultAsync();

            if (dto != null)
            {
                return dto;
            }

            return new BarberDto();
        }
    }
}
