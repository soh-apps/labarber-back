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
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Barber.Handlers
{
    public class CreateBarberHandler : IRequestHandler<CreateBarberCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;
        private readonly IBarberUseCase _barberUseCase;
        private readonly ITokenUseCase _tokenUseCase;
        private readonly ILoginUseCase _loginUseCase;

        public CreateBarberHandler(
            IMediatorHandler handler,
            IAppUserUseCase appUserUseCase,
            IBarberUnitUseCase barberUnitUseCase,
            ITokenUseCase tokenUseCase,
            ILoginUseCase loginUseCase,
            IBarberUseCase barberUSerCase)
        {
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _barberUnitUseCase = barberUnitUseCase;
            _tokenUseCase = tokenUseCase;
            _loginUseCase = loginUseCase;
            _barberUseCase = barberUSerCase;
        }

        public async Task<bool> Handle(CreateBarberCommand request, CancellationToken cancellationToken)
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

                var encryptedPassword = _tokenUseCase.EncryptPassword(input.Password);
                var createCredentialDto = new CreateCredentialDto(input.Username, encryptedPassword, input.Email, UserType.Manager);
                var credentialId = await _loginUseCase.CreateLogin(createCredentialDto);
                if (credentialId > 0)
                    await _barberUseCase.CreateBarber(new CreateBarberDto(input.Name, input.City, input.State, input.Street, input.Number, input.Complement, input.ZipCode, input.Commissioned, input.BarberUnitId, credentialId));
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
