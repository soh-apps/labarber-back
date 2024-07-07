using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Dtos.SigningPlan;
using LaBarber.Domain.Entities.SigningPlan;

namespace LaBarber.Application.SigningPlan.UseCase
{
    public class SigningPlanUseCase : ISigningPlanUseCase
    {
        private readonly ISigningPlanRepository _repository;
        private readonly IMediatorHandler _handler;

        public SigningPlanUseCase(ISigningPlanRepository repository, IMediatorHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        public async Task CreateSigningPlan(SigningPlanDto plan)
        {
            await _repository.CreatePlan(plan);
        }
    }
}
