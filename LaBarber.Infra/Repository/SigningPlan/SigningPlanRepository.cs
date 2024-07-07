using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.SigningPlan;
using LaBarber.Domain.Entities.SigningPlan;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.SigningPlan
{
    public class SigningPlanRepository : ISigningPlanRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        private readonly IOptions<Secrets> _secrets;

        public SigningPlanRepository(DbContextOptions<ContextBase> optionsBuilder, IOptions<Secrets> secrets)
        {
            _optionsBuilder = optionsBuilder;
            _secrets = secrets;
        }

        public async Task CreatePlan(SigningPlanDto plan)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);
            var entity = new SigningPlanEntity(plan);

            await context.SigningPlan.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
