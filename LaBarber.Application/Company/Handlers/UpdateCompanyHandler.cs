using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Company.Commands.UpdateCompany;
using LaBarber.Application.Company.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Company;
using MediatR;

namespace LaBarber.Application.Company.Handlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        private readonly ICompanyUseCase _useCase;
        private readonly IMediatorHandler _handler;
        private readonly IAppUserUseCase _appUserUseCase;

        public UpdateCompanyHandler(ICompanyUseCase useCase, IMediatorHandler handler, IAppUserUseCase appUserUseCase)
        {
            _useCase = useCase;
            _handler = handler;
            _appUserUseCase = appUserUseCase;
        }

        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var user = await _appUserUseCase.GetAppUserById(input.UserId);

                if ((user.CompanyId != null && user.CompanyId == input.CompanyId) || user.CompanyId == null)
                {
                    var dto = new UpdateCompanyDto(input.CompanyId, input.Name, input.CNPJ);

                    return await _useCase.UpdateCompany(dto);
                }
                
                return false;

            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}