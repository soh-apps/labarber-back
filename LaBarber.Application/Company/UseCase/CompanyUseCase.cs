using LaBarber.Domain.Dtos.Company;
using LaBarber.Domain.Entities.Company;

namespace LaBarber.Application.Company.UseCase
{
    public class CompanyUseCase : ICompanyUseCase
    {
        public readonly ICompanyRepository _repository;

        public CompanyUseCase(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CreateCompany(CreateCompanyDto dto)
        {
            return await _repository.CreateCompany(dto);
        }

        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            return await _repository.GetAllCompanies();
        }

        public async Task<CompanyDto> GetCompanyById(int companyId)
        {
            return await _repository.GetCompanyById(companyId);
        }
    }
}
