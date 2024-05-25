using FluentValidation;
using LaBarber.Application.Company.Boundaries;

namespace LaBarber.Application.Company.Commands.CreateCompany.Validation
{
    public class CreateCompanyValidation : AbstractValidator<CreateCompanyInput>
    {
        public CreateCompanyValidation()
        {
            RuleFor(x => x.SigningPlanId)
             .NotNull()
             .GreaterThan(0)
             .WithMessage("É obrigatório selecionar um plano");

             RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name da empresa é obrigatório");
        }
    }
}