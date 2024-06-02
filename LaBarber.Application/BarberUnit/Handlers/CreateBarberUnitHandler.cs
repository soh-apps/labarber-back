using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.Extensions;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.Barber;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LaBarber.Application.BarberUnit.Handlers
{
    public class CreateBarberUnitHandler : IRequestHandler<CreateBarberUnitCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitRepository _barberUnitRepository;
        public CreateBarberUnitHandler(IMediatorHandler handler, IAppUserUseCase appUserUseCase, IBarberUnitRepository barberUnitRepository)
        {
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _barberUnitRepository = barberUnitRepository;
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
                return await _barberUnitRepository.CreateBarberUnit(dto);
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
