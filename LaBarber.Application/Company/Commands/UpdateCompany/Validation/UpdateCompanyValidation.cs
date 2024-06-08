using FluentValidation;
using LaBarber.Application.Company.Boundaries;

namespace LaBarber.Application.Company.Commands.UpdateCompany.Validation
{
    public class UpdateCompanyValidation : AbstractValidator<UpdateCompanyInput>
    {
        public UpdateCompanyValidation()
        {
            RuleFor(x => x.CompanyId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Id da empresa é obrigatório");

            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Nome da empresa é obrigatório");

            RuleFor(x => x.CNPJ)
            .NotEmpty()
            .WithMessage("CNPJ é obrigatório");

            RuleFor(x => x.UserId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("Usuario inválido");
        }
    }
}