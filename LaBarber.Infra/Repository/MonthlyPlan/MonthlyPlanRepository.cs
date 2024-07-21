using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.MonthlyPlan;
using LaBarber.Domain.Entities.MonthlyPlan;
using LaBarber.Domain.Enums;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.MonthlyPlan
{
    public class MonthlyPlanRepository : IMonthlyPlanRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        private readonly IOptions<Secrets> _secrets;
        public MonthlyPlanRepository(DbContextOptions<ContextBase> optionsBuilder, IOptions<Secrets> secrets)
        {
            _optionsBuilder = optionsBuilder;
            _secrets = secrets;
        }

        public async Task<bool> CreateMonthlyPlan(MonthlyPlanDto input)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var monthlyPlan = new MonthlyPlanEntity(input);
            var created = await context.MonthlyPlan.AddAsync(monthlyPlan);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MonthlyPlanDto>> GetAllMonthlyPlans(int companyId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            return await (from monthlyPlan in context.MonthlyPlan
                          where monthlyPlan.CompanyId == companyId
                          select new MonthlyPlanDto(monthlyPlan)).AsNoTracking().ToListAsync();
        }

        public async Task<MonthlyPlanDto> GetMonthlyPlanById(int id)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var dto = await (from monthlyPlan in context.MonthlyPlan
                             where monthlyPlan.Id == id
                             select new MonthlyPlanDto(monthlyPlan)).AsNoTracking().FirstOrDefaultAsync();

            if (dto != null)
            {
                return dto;
            }

            return new MonthlyPlanDto();
        }

        public async Task<bool> UpdateMonthlyPlan(MonthlyPlanDto dto)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var entity = await context.MonthlyPlan.Where(x => x.Id == dto.Id)
                .AsNoTracking().FirstOrDefaultAsync();
            if (entity != null)
            {
                entity = new MonthlyPlanEntity(dto);
                context.MonthlyPlan.Update(entity);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
