using LaBarber.Domain.Dtos.MonthlyPlan;
using LaBarber.Domain.Entities.MonthlyPlan;

namespace LaBarber.Application.MonthlyPlan.UseCase
{
    public class MonthlyPlanUseCase : IMonthlyPlanUseCase
    {
        private readonly IMonthlyPlanRepository _repository;

        public MonthlyPlanUseCase(IMonthlyPlanRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateMonthlyPlan(MonthlyPlanDto input)
        {
            return await _repository.CreateMonthlyPlan(input);
        }

        public async Task<bool> UpdateMonthlyPlan(MonthlyPlanDto input)
        {
            return await _repository.UpdateMonthlyPlan(input);
        }

        public async Task<List<MonthlyPlanDto>> GetAllMonthlyPlans(int companyId)
        {
            return await _repository.GetAllMonthlyPlans(companyId);
        }

        public async Task<MonthlyPlanDto> GetMonthlyPlanById(int id)
        {
            return await _repository.GetMonthlyPlanById(id);
        }
    }
}