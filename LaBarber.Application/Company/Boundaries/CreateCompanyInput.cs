using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.Company.Boundaries
{
    public class CreateCompanyInput
    {
        public CreateCompanyInput(int signinPlanId, string name, string cnpj)
        {
            SigningPlanId = signinPlanId;
            Name = name;
            CNPJ = cnpj;

        }
        public CreateCompanyInput()
        {
            SigningPlanId = 0;
            Name = string.Empty;
            CNPJ = string.Empty;
        }

        [SwaggerSchema(
            Title = "SigningPlanId",
            Description = "Preencha com o Id do plano escolhido",
            Format = "int")]
        public int SigningPlanId { get; set; }

        [SwaggerSchema(
            Title = "Name",
            Description = "Preencha com o nome da empresa",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "CNPJ",
            Description = "Preencha com o CNPJ da empresa ",
            Format = "string")]
        public string CNPJ { get; set; }
    }
}
