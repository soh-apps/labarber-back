using LaBarber.Domain.Dtos.SigningPlan;

namespace LaBarber.Domain.Entities.SigningPlan
{
    public interface ISigningPlanRepository
    {
        Task CreatePlan(SigningPlanDto plan);
    }
}
