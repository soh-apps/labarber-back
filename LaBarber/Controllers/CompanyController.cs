using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands;
using LaBarber.Application.Company.Commands.CreateCompanyUser;
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
    }
}
