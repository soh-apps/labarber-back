using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.Barber;
using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.Barber;
using LaBarber.Domain.Entities.BarberUnit;
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

        public async Task<BarberDto> GetBarberByUserId(int userId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var entity = await context.Barber.Where(x => x.Id == userId).AsNoTracking().FirstOrDefaultAsync();

            if (entity != null)
            {
                return new BarberDto(entity);
            }

            return new BarberDto();
        }
    }
}
