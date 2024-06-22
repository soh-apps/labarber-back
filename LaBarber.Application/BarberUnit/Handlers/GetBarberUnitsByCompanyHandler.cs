using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands;
using LaBarber.Application.BarberUnit.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.BarberUnit.Handlers
{
    public class GetBarberUnitsByCompanyHandler : IRequestHandler<GetBarberUnitsByCompanyCommand, IEnumerable<BarberUnitOutput>>
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
        public async Task<IEnumerable<BarberUnitOutput>> Handle(GetBarberUnitsByCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var user = await _appUserUseCase.GetAppUserById(request.UserId);
                int? companyIdToSearch = request.CompanyId ?? user.CompanyId;

                if (companyIdToSearch != null && (user.CompanyId == companyIdToSearch || request.UserRole == "Master"))
                {
                    var dto = await _barberUnitUseCase.GetBarberUnitsByCompany(companyIdToSearch.Value);

                    return dto.Select(x => new BarberUnitOutput(x)).AsEnumerable();
                }
                await _handler.PublishNotification(new DomainNotification(request.MessageType, "Usuário não possui permissão necessária."));
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return [];
        }
    }
}
