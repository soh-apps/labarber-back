using FluentValidation;
using LaBarber.Application.Company.Boundaries;

namespace LaBarber.Application.Company.Commands.CreateCompanyUser.Validation
{
    public class CreateCompanyUserValidation : AbstractValidator<CreateCompanyUserInput>
    {
        public CreateCompanyUserValidation()
        {
            RuleFor(x => x.CompanyId)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Empresa é obrigatório");
            
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome do usuário é obrigatório");
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email em formato inválido");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Login do usuário é obrigatório");
        }
    }
}