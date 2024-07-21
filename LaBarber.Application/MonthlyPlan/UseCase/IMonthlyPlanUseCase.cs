using LaBarber.Domain.Dtos.MonthlyPlan;

namespace LaBarber.Application.MonthlyPlan.UseCase
{
    public interface IMonthlyPlanUseCase 
    {
        Task<bool> CreateMonthlyPlan(MonthlyPlanDto input);
        Task<bool> UpdateMonthlyPlan(MonthlyPlanDto input);
        Task<MonthlyPlanDto> GetMonthlyPlanById(int id);
        Task<List<MonthlyPlanDto>> GetAllMonthlyPlans(int companyId);
    }
}