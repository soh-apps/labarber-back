using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Service.Commands.CreateService;
using LaBarber.Application.Service.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Service;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Service.Handlers
{
    public class CreateServiceHandler : IRequestHandler<CreateServiceCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IServiceUseCase _useCase;
        private readonly IBarberUseCase _barberUseCase;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;

        public CreateServiceHandler(IServiceUseCase useCase,
        IMediatorHandler mediatorHandler,
         IBarberUseCase barberUseCase,
         IAppUserUseCase appUserUseCase,
         IBarberUnitUseCase barberUnitUseCase)
        {
            _useCase = useCase;
            _mediatorHandler = mediatorHandler;
            _barberUseCase = barberUseCase;
            _appUserUseCase = appUserUseCase;
            _barberUnitUseCase = barberUnitUseCase;
        }

        public async Task<bool> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                if (input.UserRole == UserType.Admin.ToString())
                {
                    var admin = await _appUserUseCase.GetAppUserById(request.Input.UserId);
                    if (admin.CompanyId == null)
                    {
                        await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, "O administrador precisa estar vinculado a uma empresa."));
                        return false;
                    }
                    var adminCompanyBarberUnits = await _barberUnitUseCase.GetBarberUnitsByCompany(admin.CompanyId.Value);
                    if (adminCompanyBarberUnits == null || !adminCompanyBarberUnits.Select(bu => bu.Id).Contains(request.Input.BarberUnitId))
                    {
                        await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, "Barbearia não encontrada"));
                        return false;
                    }
                }
                else
                {
                    var manager = await _barberUseCase.GetBarberByUserId(input.UserId);
                    if (manager.BarberUnitId == 0)
                    {
                        await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, "Barbearia não encontrada"));
                        return false;
                    }
                    input.BarberUnitId = manager.BarberUnitId;
                }

                var dto = new ServiceDto(0, input.Name, input.TimeToComplete, input.Value, input.CommissionPercent, input.BarberUnitId);
                await _useCase.CreateService(dto);
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}