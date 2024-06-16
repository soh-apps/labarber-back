using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Extensions;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.BarberUnit;
using MediatR;

namespace LaBarber.Application.BarberUnit.Handlers
{
    public class UpdateBarberUnitHandler : IRequestHandler<UpdateBarberUnitCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;

        public UpdateBarberUnitHandler(IMediatorHandler handler, IAppUserUseCase appUserUseCase, IBarberUnitUseCase barberUnitUseCase)
        {
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _barberUnitUseCase = barberUnitUseCase;
        }

        public async Task<bool> Handle(UpdateBarberUnitCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var user = await _appUserUseCase.GetAppUserById(input.UserId);
                if (!user.CompanyId.IsStrictlyPositive())
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "Usuário precisa pertencer a uma empresa para alterar barbearias."));
                    return false;
                }
                var barberUnit = await _barberUnitUseCase.GetBarberUnitById(input.Id);
                if (barberUnit == null || barberUnit?.Id == 0)
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "Barbearia não encontrada."));
                    return false;
                }
                var dto = new UpdateBarberUnitDto(input.Id, input.Name, input.City, input.State, input.Street, input.Number, input.Complement, input.ZipCode, barberUnit!.CompanyId);
                bool updated = await _barberUnitUseCase.UpdateBarberUnit(dto);
                if (updated && request.Input.WorkingHours != null)
                {
                    var availabilitiesDto = new List<SetBarberUnitAvailabilityDto>();
                    foreach (var availability in request.Input.WorkingHours)
                    {
                        availabilitiesDto.Add(new SetBarberUnitAvailabilityDto(availability.WorkingDays, availability.StartingHour, availability.EndingHour));
                    }
                    return await _barberUnitUseCase.SetBarberUnitAvailability(availabilitiesDto, input.Id);
                }
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
