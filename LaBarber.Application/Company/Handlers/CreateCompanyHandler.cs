using LaBarber.Application.Company.Commands;
using LaBarber.Application.Company.UseCase;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using LaBarber.Domain.Dtos.Company;
using MediatR;

namespace LaBarber.Application.Company.Handlers
{
    public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand, bool>
    {
        private readonly IMediatorHandler _handler;
        private readonly ICompanyUseCase _useCase;

        public CreateCompanyHandler(ICompanyUseCase useCase, IMediatorHandler handler)
        {
            _useCase = useCase;
            _handler = handler;
        }

        public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var input = request.Input;
                var dto = new CreateCompanyDto(input.SigningPlanId, input.Name, input.CNPJ);

                return await _useCase.CreateCompany(dto);

            }
            foreach (var error in request.ValidationResult.Errors)
            {
                await _handler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}