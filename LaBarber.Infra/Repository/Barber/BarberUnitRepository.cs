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
        public async Task<int> CreateBarberUnit(CreateBarberUnitDto input)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var barberUnit = new BarberUnitEntity(input);
            var created = await context.BarberUnit.AddAsync(barberUnit);
            await context.SaveChangesAsync();
            return created?.Entity?.Id ?? 0;
        }

        public async Task<bool> UpdateBarberUnit(UpdateBarberUnitDto input)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var barberUnit = new BarberUnitEntity(input);
            var created = context.BarberUnit.Update(barberUnit);
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

        public async Task<bool> CreateBarberUnitAvailabilities(IEnumerable<CreateBarberUnitAvailabilityDto> availabilitiesDto)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var availabilities = new List<BarberUnitAvailabilityEntity>();
            foreach (var availabilityDto in availabilitiesDto)
            {
                availabilities.Add(new BarberUnitAvailabilityEntity(availabilityDto.WorkingDay, availabilityDto.StartingHour, availabilityDto.EndingHour, availabilityDto.BarberUnitId));
            }
            await context.BarberUnitAvailability.AddRangeAsync(availabilities);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAllBarberUnitAvailabilities(int barberUnitId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var currentAvailabilities = await context.BarberUnitAvailability.Where(av => av.BarberUnitId == barberUnitId).ToListAsync();
            context.BarberUnitAvailability.RemoveRange(currentAvailabilities);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<BarberUnitDto> GetBarberUnitById(int barberUnitId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var result = await context.BarberUnit
                .Where(x => x.Id == barberUnitId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return new BarberUnitDto();
            }
            return new BarberUnitDto(result.Id, result.Name, result.City, result.State, result.Street, result.Number, result.Complement, result.ZipCode, result.CompanyId, result.Status);
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

        public async Task<IEnumerable<BarberUnitAvailabilityDto>> GetBarberUnitAvailability(int barberUnitId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            return await (from barberUnitAvailability in context.BarberUnitAvailability
                          where barberUnitAvailability.BarberUnitId == barberUnitId
                          select new BarberUnitAvailabilityDto(barberUnitAvailability.WorkingDay, barberUnitAvailability.StartWorkingHour, barberUnitAvailability.EndWorkingHour, barberUnitId))
                          .AsNoTracking()
                          .ToListAsync();
        }
    }
}
