using LaBarber.Domain.Dtos.Company;

namespace LaBarber.Application.Company.UseCase
{
    public interface ICompanyUseCase
    {
    Task<bool> CreateCompany(CreateCompanyDto dto);
    }

}