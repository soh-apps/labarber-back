﻿using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.BarberUnit;
using LaBarber.Domain.Dtos.Login;
using LaBarber.Domain.Enums;
using MediatR;

namespace LaBarber.Application.BarberUnit.Handlers
{
    public class CreateBarberUnitManagerHandler : IRequestHandler<CreateBarberUnitManagerCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;
        private readonly ITokenUseCase _tokenUseCase;
        private readonly ILoginUseCase _loginUseCase;

        public CreateBarberUnitManagerHandler(
            IMediatorHandler handler,
            IAppUserUseCase appUserUseCase,
            IBarberUnitUseCase barberUnitUseCase,
            ITokenUseCase tokenUseCase,
            ILoginUseCase loginUseCase)
        {
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _barberUnitUseCase = barberUnitUseCase;
            _tokenUseCase = tokenUseCase;
            _loginUseCase = loginUseCase;
        }

        public async Task<bool> Handle(CreateBarberUnitManagerCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var admin = await _appUserUseCase.GetAppUserById(request.Input.AdminId);
                if (admin.CompanyId == null)
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "O administrador precisa estar vinculado a uma empresa."));
                    return false;
                }
                var adminCompanyBarberUnits = await _barberUnitUseCase.GetBarberUnitsByCompany(admin.CompanyId.Value);
                if (adminCompanyBarberUnits == null || !adminCompanyBarberUnits.Select(bu => bu.Id).Contains(request.Input.BarberUnitId))
                {
                    await _handler.PublishNotification(new DomainNotification(request.MessageType, "A barbearia informada não pertence à empresa do usuário."));
                    return false;
                }
                var encryptedPassword = _tokenUseCase.EncryptPassword(input.Password);
                var createCredentialDto = new CreateCredentialDto(input.Username, encryptedPassword, input.Email, UserType.Manager);
                var credentialId = await _loginUseCase.CreateLogin(createCredentialDto);
                await _barberUnitUseCase.CreateBarberUnitManager(new CreateBarberUnitManagerDto(input.Name, input.City, input.State, input.Street, input.Number, input.Complement, input.ZipCode, input.Commissioned, input.BarberUnitId, credentialId));
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}