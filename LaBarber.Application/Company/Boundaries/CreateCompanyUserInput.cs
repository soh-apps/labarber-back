using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.Application.Company.Boundaries
{
    public class CreateCompanyUserInput
    {
        public CreateCompanyUserInput()
        {
            Name = string.Empty;
            UserName = string.Empty;
            CompanyId = 0;
            Email = string.Empty;
            Password = string.Empty;
        }


        [SwaggerSchema(
            Title = "Name",
            Description = "Preencha com o nome do usuário da empresa",
            Format = "string")]
        public string Name { get; set; }

        [SwaggerSchema(
            Title = "UserName",
            Description = "Preencha com nome de usuário da empresa, utilizado para autenticação",
            Format = "string")]
        public string UserName { get; set; }

        [SwaggerSchema(
            Title = "CompanyId",
            Description = "Preencha com o Id do da empresa",
            Format = "int")]
        public int CompanyId { get; set; }

        [SwaggerSchema(
            Title = "Email",
            Description = "Preencha com o e-mail do usuário da empresa",
            Format = "string")]
        public string Email { get; set; }

        //TODO remover isso quando implementar a troca de senha
        [SwaggerSchema(
            Title = "Password",
            Description = "Preencha com a senha do usuário da empresa a ser criado",
            Format = "string")]
        public string Password { get; set; }
    }
}