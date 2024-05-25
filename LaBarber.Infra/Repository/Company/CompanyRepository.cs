using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.Company;
using LaBarber.Domain.Entities.Company;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        private readonly IOptions<Secrets> _secrets;

        public CompanyRepository(IOptions<Secrets> secrets)
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
            _secrets = secrets;
        }

        public async Task<bool> CreateCompany(CreateCompanyDto dto)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var company = new CompanyEntity(dto);

            await context.Company.AddAsync(company);

            await context.SaveChangesAsync();

            return true;
        }
    }
}