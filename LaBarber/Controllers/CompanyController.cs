using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands;
using LaBarber.Application.Company.Commands.CreateCompanyUser;
using LaBarber.Application.Company.Commands.GetAllCompanies;
using LaBarber.Application.Company.Commands.GetCompanyById;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CompanyController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public CompanyController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("CreateCompany")]
        [Authorize(Roles = "Master")]
        [SwaggerResponse(201, "Empresa criada com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> CreateCompany(CreateCompanyInput company)
        {
            var command = new CreateCompanyCommand(company);

            await _handler.SendCommand<CreateCompanyCommand, bool>(command);

            if (IsValidOperation())
            {
                return Created();
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpPost("CreateCompanyUser")]
        [Authorize(Roles = "Master")]
        [SwaggerResponse(201, "usuario criado com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> CreateCompanyUser(CreateCompanyUserInput user)
        {
            var command = new CreateCompanyUserCommand(user);

            await _handler.SendCommand<CreateCompanyUserCommand, bool>(command);

            if (IsValidOperation())
            {
                return Created();
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("GetAllCompanies")]
        [Authorize(Roles = "Master")]
        [SwaggerResponse(200, "Todas as empresas", typeof(List<CompanyOutput>))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetAllCompanies()
        {
            var command = new GetAllCompaniesCommand();

            var companies = await _handler.SendCommand<GetAllCompaniesCommand, List<CompanyOutput>>(command);

            if (IsValidOperation())
            {
                return Ok(companies);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("GetCompanyById/{id}")]
        [Authorize(Roles = "Master,Admin")]
        [SwaggerResponse(200, "Empresa", typeof(CompanyOutput))]
        [SwaggerResponse(404, "Empresa não encontrada")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetCompanyById([FromRoute] int id)
        {
            var userId = GetUserId();
            var command = new GetCompanyByIdCommand(id, userId);

            var company = await _handler.SendCommand<GetCompanyByIdCommand, CompanyOutput>(command);

            if (IsValidOperation())
            {
                if (company.Id == 0)
                    return NotFound();

                return Ok(company);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }
    }
}
