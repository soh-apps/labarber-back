using LaBarber.Application.Service.Boundaries;
using LaBarber.Application.Service.Commands.CreateService;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public ServiceController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "Criar serviço da barbearia",
            Description = "Criar um serviço associado à unidade da barbearia selecionada")]
        [SwaggerResponse(201, "Usuário da barbearia criada com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> CreateBarber([FromBody] ServiceInput input)
        {
            input.SetUserId(GetUserId());
            input.SetUserRole(GetUserRole());

            var command = new CreateServiceCommand(input);

            await _handler.SendCommand<CreateServiceCommand, bool>(command);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }
    }
}
