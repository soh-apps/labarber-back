﻿using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Extensions;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.BarberUnit;
using MediatR;

namespace LaBarber.Application.BarberUnit.Handlers
{
    public class CreateBarberUnitHandler : IRequestHandler<CreateBarberUnitCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;
        public CreateBarberUnitHandler(IMediatorHandler handler, IAppUserUseCase appUserUseCase, IBarberUnitUseCase barberUnitUseCase)
        {
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _barberUnitUseCase = barberUnitUseCase;
        }
        public async Task<bool> Handle(CreateBarberUnitCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var user = await _appUserUseCase.GetAppUserById(input.UserId);
                if (!user.CompanyId.IsStrictlyPositive())
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "Usuário precisa pertencer a uma empresa para criar barbearias."));
                    return false;
                }
                var dto = new CreateBarberUnitDto(input.Name, input.City, input.State, input.Street, input.Number, input.Complement, input.ZipCode, user.CompanyId!.Value);
                int barberUnitId = await _barberUnitUseCase.CreateBarberUnit(dto);
                if (barberUnitId > 0 && request.Input.WorkingHours != null)
                {
                    var availabilitiesDto = new List<SetBarberUnitAvailabilityDto>();
                    foreach (var availability in request.Input.WorkingHours)
                    {
                        availabilitiesDto.Add(new SetBarberUnitAvailabilityDto(availability.WorkingDays, availability.StartingHour, availability.EndingHour));
                    }
                    return await _barberUnitUseCase.SetBarberUnitAvailability(availabilitiesDto, barberUnitId);
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
