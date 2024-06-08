using System.Security.Cryptography.X509Certificates;
using LaBarber.Application.Company.Boundaries;
using LaBarber.Domain.Base.Messages;

namespace LaBarber.Application.Company.Commands.GetAllCompanies
{
    public class GetAllCompaniesCommand : Command<List<CompanyOutput>>
    {
        public GetAllCompaniesCommand()
        {

        }

        public override bool IsValid()
        {
            return true;
        }
    }
}