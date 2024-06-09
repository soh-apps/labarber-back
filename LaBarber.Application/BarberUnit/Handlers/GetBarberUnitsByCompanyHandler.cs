using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.BarberUnit;
using MediatR;

namespace LaBarber.Application.BarberUnit.Handlers
{
    public class GetBarberUnitsByCompanyHandler : IRequestHandler<GetBarberUnitsByCompanyCommand, IEnumerable<BarberUnitDto>>
    {
        private readonly IMediatorHandler _handler;
        private readonly IAppUserUseCase _appUserUseCase;
        private readonly IBarberUnitUseCase _barberUnitUseCase;
        public GetBarberUnitsByCompanyHandler(IMediatorHandler handler, IAppUserUseCase appUserUseCase, IBarberUnitUseCase barberUnitUseCase)
        {
            _handler = handler;
            _appUserUseCase = appUserUseCase;
            _barberUnitUseCase = barberUnitUseCase;
        }
        public async Task<IEnumerable<BarberUnitDto>> Handle(GetBarberUnitsByCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var user = await _appUserUseCase.GetAppUserById(request.UserId);

                if ((user.CompanyId != null && user.CompanyId == request.CompanyId) || request.UserRole == "Master")
                {
                    return await _barberUnitUseCase.GetBarberUnitsByCompany(request.CompanyId);
                }
                await _handler.PublishNotification(new DomainNotification(request.MessageType, "Usuário não possui permissão necessária."));
                return new List<BarberUnitDto>();
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new List<BarberUnitDto>();
        }
    }
}
