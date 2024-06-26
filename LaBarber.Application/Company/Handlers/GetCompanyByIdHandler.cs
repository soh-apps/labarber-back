using LaBarber.Application.AppUser.UseCase;
using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands.GetCompanyById;
using LaBarber.Application.Company.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.Company.Handlers
{
    public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdCommand, CompanyOutput>
    {
        private readonly IMediatorHandler _handler;
        private readonly ICompanyUseCase _useCase;
        private readonly IAppUserUseCase _appUserUseCase;

        public GetCompanyByIdHandler(ICompanyUseCase useCase, IMediatorHandler handler, IAppUserUseCase appUserUseCase)
        {
            _useCase = useCase;
            _handler = handler;
            _appUserUseCase = appUserUseCase;
        }

        public async Task<CompanyOutput> Handle(GetCompanyByIdCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var user = await _appUserUseCase.GetAppUserById(request.UserId);

                if ((user.CompanyId != null && user.CompanyId == request.CompanyId) || user.CompanyId == null)
                {
                    var company = await _useCase.GetCompanyById(request.CompanyId);
                    return new CompanyOutput(company);
                }
                return new CompanyOutput();
            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return new CompanyOutput();
        }
    }
}