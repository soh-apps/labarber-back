using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.MonthlyPlan.Commands;
using LaBarber.Application.MonthlyPlan.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.MonthlyPlan;
using MediatR;

namespace LaBarber.Application.MonthlyPlan.Handlers
{
    public class UpdateMonthlyPlanHandler : IRequestHandler<UpdateMonthlyPlanCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly IMonthlyPlanUseCase _monthlyPlanUseCase;
        private readonly IAppUserUseCase _appUserUseCase;

        public UpdateMonthlyPlanHandler(
            IMediatorHandler handler,
            IMonthlyPlanUseCase monthlyPlanUserCase,
            IAppUserUseCase appUserUseCase)
        {
            _handler = handler;
            _monthlyPlanUseCase = monthlyPlanUserCase;
            _appUserUseCase = appUserUseCase;
        }

        public async Task<bool> Handle(UpdateMonthlyPlanCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input; 
                var admin = await _appUserUseCase.GetAppUserById(request.Input.UserId);
                if (admin.CompanyId == null)
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "O administrador precisa estar vinculado a uma empresa."));
                    return false;
                }
                var existingMonthlyPlan = await _monthlyPlanUseCase.GetMonthlyPlanById(input.Id);
                if (existingMonthlyPlan.Id == 0)
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "Plano não encontrado"));
                    return false;
                }
                var success = await _monthlyPlanUseCase.UpdateMonthlyPlan(new MonthlyPlanDto(input.Id, input.Name, input.Description, input.Value, existingMonthlyPlan.CompanyId));

                if (!success)
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "Plano não foi atualizado"));
                }

                return true;
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
