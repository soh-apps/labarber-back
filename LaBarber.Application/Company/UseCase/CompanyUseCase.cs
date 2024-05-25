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
    }
}
