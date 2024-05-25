using LaBarber.Domain.Enums;

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

        public string Name { get; set; }
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }

        //TODO remover isso quando implementar a troca de senha
        public string Password { get; set; }
    }
}