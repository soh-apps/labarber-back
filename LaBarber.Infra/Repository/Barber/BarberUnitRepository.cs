using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.Barber;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.Barber
{
    public class BarberUnitRepository : IBarberUnitRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        private readonly IOptions<Secrets> _secrets;
        public BarberUnitRepository(DbContextOptions<ContextBase> optionsBuilder, IOptions<Secrets> secrets)
        {
            _optionsBuilder = optionsBuilder;
            _secrets = secrets;
        }
        public async Task<bool> CreateBarberUnit(CreateBarberUnitDto input)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var barberUnit = new BarberUnitEntity(input);
            var created = await context.BarberUnit.AddAsync(barberUnit);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
