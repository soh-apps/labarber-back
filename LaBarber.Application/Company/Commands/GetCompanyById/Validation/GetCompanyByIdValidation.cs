using FluentValidation;

namespace LaBarber.Application.Company.Commands.GetCompanyById.Validation
{
    public class GetCompanyByIdValidation : AbstractValidator<GetCompanyByIdCommand>
    {
        public GetCompanyByIdValidation()
        {
            RuleFor(x => x.CompanyId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Id da empresa é obrigatório");

            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("É obrigatório o usuario estar logado");
        }
    }
}