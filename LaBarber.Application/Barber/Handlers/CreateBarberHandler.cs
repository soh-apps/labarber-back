using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Barber.Commands;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Barber;
using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.Barber.Handlers
{
    public class CreateBarberHandler : IRequestHandler<CreateBarberCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly ITokenUseCase _tokenUseCase;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IBarberUseCase _barberUseCase;

        public CreateBarberHandler(
            IMediatorHandler handler,
            ITokenUseCase tokenUseCase,
            ILoginUseCase loginUseCase,
            IBarberUseCase barberUseCase)
        {
            _handler = handler;
            _tokenUseCase = tokenUseCase;
            _loginUseCase = loginUseCase;
            _barberUseCase = barberUseCase;
        }

        public async Task<bool> Handle(CreateBarberCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var manager = await _barberUseCase.GetBarberByUserId(input.UserId);

                var encryptedPassword = _tokenUseCase.EncryptPassword(input.Password);
                var createCredentialDto = new CreateCredentialDto(input.Username, encryptedPassword, input.Email, UserType.Manager);
                var credentialId = await _loginUseCase.CreateLogin(createCredentialDto);

                if (credentialId > 0)
                    await _barberUseCase.CreateBarber(new CreateBarberDto(input.Name, input.City, input.State, input.Street, input.Number, input.Complement, input.ZipCode, input.Commissioned, manager.BarberUnitId, credentialId));
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}
