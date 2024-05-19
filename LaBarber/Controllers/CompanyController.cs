using LaBarber.Application.Company.Boundaries;
using Microsoft.AspNetCore.Mvc;

namespace LaBarber.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        public CompanyController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<CompanyOutput> company = new List<CompanyOutput>()
            {
                new CompanyOutput()
                {
                    Id = 1,
                    Name = "Teste"
                }
            };
            return Ok(await Task.FromResult(company));
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewCompanyInput company)
        {
            return Ok();
        }
    }
}
