using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.MonthlyPlan.Commands;
using LaBarber.Application.MonthlyPlan.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.MonthlyPlan;
using MediatR;

namespace LaBarber.Application.MonthlyPlan.Handlers
{
    public class CreateMonthlyPlanHandler : IRequestHandler<CreateMonthlyPlanCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly IMonthlyPlanUseCase _monthlyPlanUseCase;
        private readonly IAppUserUseCase _appUserUseCase;

        public CreateMonthlyPlanHandler(
            IMediatorHandler handler,
            IMonthlyPlanUseCase monthlyPlanUserCase,
            IAppUserUseCase appUserUseCase)
        {
            _handler = handler;
            _monthlyPlanUseCase = monthlyPlanUserCase;
            _appUserUseCase = appUserUseCase;
        }

        public async Task<bool> Handle(CreateMonthlyPlanCommand request, CancellationToken cancellationToken)
        {
            var input = request.Input;
            if (request.IsValid())
            {
                var userId = input.UserId;
                var admin = await _appUserUseCase.GetAppUserById(request.Input.UserId);
                if (admin.CompanyId == null)
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "O administrador precisa estar vinculado a uma empresa."));
                    return false;
                }
                await _monthlyPlanUseCase.CreateMonthlyPlan(new MonthlyPlanDto(input.Name, input.Description, input.Value, admin.CompanyId.Value));
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
