using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.MonthlyPlan.Boundaries;
using LaBarber.Application.MonthlyPlan.Commands;
using LaBarber.Application.MonthlyPlan.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.MonthlyPlan.Handlers
{
    public class GetAllMonthlyPlansHandler : IRequestHandler<GetAllMonthlyPlansCommand, List<MonthlyPlanOutput>>
    {
        private readonly IMediatorHandler _handler;
        private readonly IMonthlyPlanUseCase _monthlyPlanUseCase;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUseCase _barberUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;

        public GetAllMonthlyPlansHandler(
            IMediatorHandler handler,
            IMonthlyPlanUseCase monthlyPlanUserCase,
            IAppUserUseCase appUserUseCase,
            IBarberUseCase barberUseCase,
            IBarberUnitUseCase barberUnitUseCase)
        {
            _handler = handler;
            _monthlyPlanUseCase = monthlyPlanUserCase;
            _appUserUseCase = appUserUseCase;
            _barberUseCase = barberUseCase;
            _barberUnitUseCase = barberUnitUseCase;
        }

        public async Task<List<MonthlyPlanOutput>> Handle(GetAllMonthlyPlansCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                int companyId = 0;
                if (request.UserRole == "Admin")
                {
                    var admin = await _appUserUseCase.GetAppUserById(request.Id);
                    if (admin.CompanyId == null)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "O administrador precisa estar vinculado a uma empresa."));
                        return [];
                    }
                    companyId = admin.CompanyId.Value;
                } 
                else
                {
                    var manager = await _barberUseCase.GetBarberByUserId(request.Id);
                    if (manager.BarberUnitId <= 0)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "O barbeiro precisa estar vinculado a uma barbearia."));
                        return [];
                    }
                    var managerBarberUnit = await _barberUnitUseCase.GetBarberUnitById(manager.BarberUnitId);
                    if (managerBarberUnit.CompanyId <= 0)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "A barbearia do barbeiro precisa estar vinculado a uma empresa."));
                        return [];
                    }
                    companyId = managerBarberUnit.CompanyId;
                }
				var monthlyPlans = await _monthlyPlanUseCase.GetAllMonthlyPlans(companyId);

				return monthlyPlans.Select(x => new MonthlyPlanOutput(x)).ToList();
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return [];
        }
    }
}
