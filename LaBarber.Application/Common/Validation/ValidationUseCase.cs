
using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Barber.UseCase;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Enums;

namespace LaBarber.Application.Common.Validation
{
    public class ValidationUseCase : IValidationUseCase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IBarberUseCase _barberUseCase;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;

        public ValidationUseCase(IBarberUnitUseCase barberUnitUseCase, IAppUserUseCase appUserUseCase,
         IBarberUseCase barberUseCase, IMediatorHandler mediatorHandler)
        {
            _barberUnitUseCase = barberUnitUseCase;
            _appUserUseCase = appUserUseCase;
            _barberUseCase = barberUseCase;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<int> ChecksRealBarberUnitId(int userId, int barberUnitId, string role)
        {
            if (role == UserType.Admin.ToString())
            {
                var admin = await _appUserUseCase.GetAppUserById(userId);
                if (admin.CompanyId == null)
                {
                    await _mediatorHandler.PublishNotification(new DomainNotification("Validation", "O administrador precisa estar vinculado a uma empresa."));
                    return 0;
                }
                var adminCompanyBarberUnits = await _barberUnitUseCase.GetBarberUnitsByCompany(admin.CompanyId.Value);
                if (adminCompanyBarberUnits == null || !adminCompanyBarberUnits.Select(bu => bu.Id).Contains(barberUnitId))
                {
                    await _mediatorHandler.PublishNotification(new DomainNotification("Validation", "Barbearia não encontrada"));
                    return 0;
                }
            }
            else
            {
                var manager = await _barberUseCase.GetBarberByUserId(userId);
                if (manager.BarberUnitId == 0)
                {
                    await _mediatorHandler.PublishNotification(new DomainNotification("Validation", "Barbearia não encontrada"));
                    return 0;
                }

                barberUnitId = manager.BarberUnitId;
            }

            return barberUnitId;
        }

        // Bem similar mas com propósitos diferentes
        public async Task<bool> UserHasPermissionOnBarberUnit(int userId, int barberUnitId, string role)
        {
            if (role == UserType.Admin.ToString())
            {
                var admin = await _appUserUseCase.GetAppUserById(userId);
                if (admin.CompanyId == null)
                {
                    await _mediatorHandler.PublishNotification(new DomainNotification("Validation", "O administrador precisa estar vinculado a uma empresa."));
                    return false;
                }
                var adminCompanyBarberUnits = await _barberUnitUseCase.GetBarberUnitsByCompany(admin.CompanyId.Value);
                if (adminCompanyBarberUnits == null || !adminCompanyBarberUnits.Select(bu => bu.Id).Contains(barberUnitId))
                {
                    await _mediatorHandler.PublishNotification(new DomainNotification("Validation", "Barbearia não encontrada"));
                    return false;
                }
            }
            else
            {
                var manager = await _barberUseCase.GetBarberByUserId(userId);
                if (manager.BarberUnitId != barberUnitId)
                {
                    await _mediatorHandler.PublishNotification(new DomainNotification("Validation", "Barbearia não encontrada"));
                    return false;
                }
            }

            return true;
        }
    }
}