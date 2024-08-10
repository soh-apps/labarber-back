using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.Service;
using LaBarber.Domain.Entities.Service;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.Service
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        private readonly IOptions<Secrets> _secrets;
        public ServiceRepository(DbContextOptions<ContextBase> optionsBuilder, IOptions<Secrets> secrets)
        {
            _optionsBuilder = optionsBuilder;
            _secrets = secrets;
        }
        public async Task CreateService(ServiceDto dto)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var entity = new ServiceEntity(dto);

            await context.Service.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<ServiceDto> GetServiceById(int id)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var entity = await context.Service.Where(x => x.Id == id).Select(x => new ServiceDto(x)).AsNoTracking().FirstOrDefaultAsync();

            if (entity == null)
            {
                return new ServiceDto();
            }
            return entity;
        }

        public async Task<List<ServiceDto>> ListServicesByBarberUnit(int barberUnitId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            return await context.Service.Where(x => x.BarberUnitId == barberUnitId)
            .Select(x => new ServiceDto(x)).AsNoTracking().ToListAsync();
        }

        public async Task<bool> ServiceExists(int id)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            return await context.Service.Where(x => x.Id == id).AsNoTracking().AnyAsync();
        }

        public async Task UpdateService(ServiceDto dto)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var entity = new ServiceEntity(dto);

            context.Service.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteServiceById(int id)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var entity = await context.Service.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (entity != null)
            {
                context.Service.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}