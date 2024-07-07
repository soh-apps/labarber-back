using LaBarber.Domain.Dtos.SigningPlan;

namespace LaBarber.Application.SigningPlan.UseCase
{
    public interface ISigningPlanUseCase
    {
        Task CreateSigningPlan(SigningPlanDto plan);
    }
}
