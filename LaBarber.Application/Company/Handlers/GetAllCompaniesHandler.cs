using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands.GetAllCompanies;
using LaBarber.Application.Company.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.Company.Handlers
{
    public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesCommand, List<CompanyOutput>>
    {
        private readonly IMediatorHandler _handler;
        private readonly ICompanyUseCase _useCase;

        public GetAllCompaniesHandler(ICompanyUseCase useCase, IMediatorHandler handler)
        {
            _useCase = useCase;
            _handler = handler;
        }

        public async Task<List<CompanyOutput>> Handle(GetAllCompaniesCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {

                var companies = await _useCase.GetAllCompanies();

                return companies.Select(c => new CompanyOutput(c)).ToList();

            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return [];
        }
    }
}