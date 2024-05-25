using LaBarber.Domain.Dtos.Company;

namespace LaBarber.Domain.Entities.Company
{
    public interface ICompanyRepository
    {
        Task<bool> CreateCompany(CreateCompanyDto dto);
    }
}