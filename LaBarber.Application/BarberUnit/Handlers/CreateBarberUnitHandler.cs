using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Entities.Barber;
using MediatR;

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
                var dto = new CreateBarberUnitDto(input.Name, input.City, input.State, input.Street, input.Number, input.Complement, input.ZipCode, user.CompanyId!.Value);
                return await _barberUnitRepository.CreateBarberUnitAsync(dto);
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
