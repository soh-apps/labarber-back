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

        public async Task<bool> CreateBarberUnitManager(CreateBarberUnitManagerDto input)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var barberUnit = new BarberEntity(input);
            var created = await context.Barber.AddAsync(barberUnit);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BarberUnitDto>> GetBarberUnitsByCompany(int companyId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            return await (from barberUnit in context.BarberUnit
                          where barberUnit.CompanyId == companyId
                          select new BarberUnitDto(barberUnit.Id,barberUnit.Name,barberUnit.City,barberUnit.State,barberUnit.Street,barberUnit.Number,barberUnit.Complement,barberUnit.ZipCode,barberUnit.CompanyId,barberUnit.Status))
                          .AsNoTracking()
                          .ToListAsync();
        }
    }
}
