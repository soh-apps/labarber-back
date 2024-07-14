using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Barber.Commands;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Barber;
using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Entities.Barber;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Barber.Handlers
{
    public class UpdateBarberHandler : IRequestHandler<UpdateBarberCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly IBarberUnitUseCase _barberUnitUseCase;
        private readonly IBarberUseCase _barberUseCase;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly ILoginUseCase _loginUseCase;

        public UpdateBarberHandler(
            IMediatorHandler handler,
            IBarberUnitUseCase barberUnitUseCase,
            IBarberUseCase barberUSerCase,
            IAppUserUseCase appUserUseCase,
            ILoginUseCase loginUseCase)
        {
            _handler = handler;
            _barberUnitUseCase = barberUnitUseCase;
            _barberUseCase = barberUSerCase;
            _appUserUseCase = appUserUseCase;
            _loginUseCase = loginUseCase;
        }

        public async Task<bool> Handle(UpdateBarberCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                if (input.UserRole == UserType.Admin.ToString())
                {
                    var admin = await _appUserUseCase.GetAppUserById(request.Input.UserId);
                    if (admin.CompanyId == null)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "O administrador precisa estar vinculado a uma empresa."));
                        return false;
                    }
                    var adminCompanyBarberUnits = await _barberUnitUseCase.GetBarberUnitsByCompany(admin.CompanyId.Value);
                    if (adminCompanyBarberUnits == null || !adminCompanyBarberUnits.Select(bu => bu.Id).Contains(request.Input.BarberUnitId))
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "Barbearia não encontrada"));
                        return false;
                    }
                }
                else
                {
                    var manager = await _barberUseCase.GetBarberByUserId(input.UserId);
                    if (manager.BarberUnitId == 0)
                    {
                        await _handler.PublishNotification(new DomainNotification(request.MessageType, "Barbearia não encontrada"));
                        return false;
                    }
                    input.BarberUnitId = manager.BarberUnitId;
                }

                var profileId = input.IsManager ? (int)UserType.Manager : (int)UserType.Barber;

                await _loginUseCase.ChangeBarberProfile(profileId, input.BarberId);

                var success = await _barberUseCase.UpdateBarber(new BarberDto(input.BarberId, input.Name, input.City, input.State, input.Street,
                 input.Number, input.Complement, input.ZipCode, input.Phone, input.Cellphone, input.Commissioned,
                input.BarberUnitId, 0, input.Status));

                if (!success)
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "Barbeiro não foi atualizado"));
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
