using LaBarber.Domain.Dtos.MonthlyPlan;

namespace LaBarber.Domain.Entities.MonthlyPlan
{
    public interface IMonthlyPlanRepository
    {
        Task<bool> CreateMonthlyPlan(MonthlyPlanDto dto);
        Task<bool> UpdateMonthlyPlan(MonthlyPlanDto dto);
        Task<MonthlyPlanDto> GetMonthlyPlanById(int id);
        Task<List<MonthlyPlanDto>> GetAllMonthlyPlans(int companyId);
    }
}