using LaBarber.Domain.Configuration;
using LaBarber.Domain.Dtos.Company;
using LaBarber.Domain.Entities.Company;
using LaBarber.Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LaBarber.Infra.Repository.Company
{
    public class CompanyRepository(IOptions<Secrets> secrets) : ICompanyRepository
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder = new();
        private readonly IOptions<Secrets> _secrets = secrets;

        public async Task<bool> CreateCompany(CreateCompanyDto dto)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var company = new CompanyEntity(dto);

            await context.Company.AddAsync(company);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            return await (from company in context.Company
                          join plan in context.SigningPlan on
                          company.SigningPlanId equals plan.Id
                          select new CompanyDto(company, plan.Name)).AsNoTracking().ToListAsync();
        }

        public async Task<CompanyDto> GetCompanyById(int companyId)
        {
            using var context = new ContextBase(_optionsBuilder, _secrets);

            var companyDto = await (from company in context.Company
                                    join plan in context.SigningPlan on
                                    company.SigningPlanId equals plan.Id
                                    where company.Id == companyId
                                    select new CompanyDto(company, plan.Name)).AsNoTracking().FirstOrDefaultAsync();

            if (companyDto != null)
                return companyDto;

            return new CompanyDto();
        }
    }
}