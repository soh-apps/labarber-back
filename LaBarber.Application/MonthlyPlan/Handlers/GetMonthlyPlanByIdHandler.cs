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
    public class GetMonthlyPlanByIdHandler : IRequestHandler<GetMonthlyPlanByIdCommand, MonthlyPlanOutput>
    {
        private readonly IMediatorHandler _handler;
        private readonly IMonthlyPlanUseCase _monthlyPlanUseCase;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUseCase _barberUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;

        public GetMonthlyPlanByIdHandler(IMonthlyPlanUseCase monthlyPlanUseCase, IMediatorHandler handler, IAppUserUseCase appUserUseCase, IBarberUseCase barberUseCase, IBarberUnitUseCase barberUnitUseCase)
        {
            _monthlyPlanUseCase = monthlyPlanUseCase;
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _barberUseCase = barberUseCase;
            _barberUnitUseCase = barberUnitUseCase;
        }

        public async Task<MonthlyPlanOutput> Handle(GetMonthlyPlanByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                int companyId = 0;
                if (request.UserRole == "Admin")
                {
                    var admin = await _appUserUseCase.GetAppUserById(request.UserId);
                    if (admin.CompanyId == null)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "O administrador precisa estar vinculado a uma empresa."));
                        return new MonthlyPlanOutput();
                    }
                    companyId = admin.CompanyId.Value;
                }
                else
                {
                    var manager = await _barberUseCase.GetBarberByUserId(request.Id);
                    if (manager.BarberUnitId <= 0)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "O barbeiro precisa estar vinculado a uma barbearia."));
                        return new MonthlyPlanOutput();
                    }
                    var managerBarberUnit = await _barberUnitUseCase.GetBarberUnitById(manager.BarberUnitId);
                    if (managerBarberUnit.CompanyId <= 0)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "A barbearia do barbeiro precisa estar vinculado a uma empresa."));
                        return new MonthlyPlanOutput();
                    }
                    companyId = managerBarberUnit.CompanyId;
                }
                var monthlyPlan = await _monthlyPlanUseCase.GetMonthlyPlanById(request.Id);
                if (monthlyPlan.CompanyId == companyId)
                    return new MonthlyPlanOutput(monthlyPlan);

                await _handler.PublishNotification(new DomainNotification(request.MessageType, "Plano não encontrado."));
                return new MonthlyPlanOutput();
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new MonthlyPlanOutput();
        }
    }
}