using LaBarber.Application.Service.Boundaries;
using LaBarber.Application.Service.Commands.CreateService;
using LaBarber.Application.Service.Commands.DeleteService;
using LaBarber.Application.Service.Commands.GetService;
using LaBarber.Application.Service.Commands.ListServices;
using LaBarber.Application.Service.Commands.UpdateService;
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
        public ServiceController(INotificationHandler<DomainNotification> notificationHandler,
         IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "Criar serviço da barbearia",
            Description = "Criar um serviço associado à unidade da barbearia selecionada")]
        [SwaggerResponse(201, "Serviço da barbearia criada com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> CreateService([FromBody] ServiceInput input)
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

        [HttpPut("Update")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "Atualizar serviço da barbearia",
            Description = "Atualiza um serviço associado à unidade da barbearia selecionada")]
        [SwaggerResponse(204, "Serviço da barbearia atualizado com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> UpdateService([FromBody] ServiceInput input)
        {
            input.SetUserId(GetUserId());
            input.SetUserRole(GetUserRole());

            var command = new UpdateServiceCommand(input);

            await _handler.SendCommand<UpdateServiceCommand, bool>(command);

            if (IsValidOperation())
            {
                return NoContent();
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "Pegar serviço da barbearia",
            Description = "Pega as informações de um serviço pelo Id")]
        [SwaggerResponse(200, "Serviço da barbearia", typeof(ServiceOutput))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetService([FromRoute] int id)
        {

            var command = new GetServiceCommand(id, GetUserId(), GetUserRole());

            var respnse = await _handler.SendCommand<GetServiceCommand, ServiceOutput>(command);

            if (IsValidOperation())
            {
                return Ok(respnse);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "apaga serviço da barbearia",
            Description = "apaga um serviço pelo Id")]
        [SwaggerResponse(204, "Serviço removido")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> DeleteService([FromRoute] int id)
        {

            var command = new DeleteServiceCommand(id, GetUserId(), GetUserRole());

            await _handler.SendCommand<DeleteServiceCommand, bool>(command);

            if (IsValidOperation())
            {
                return NoContent();
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("List")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "Listar serviços da barbearia",
            Description = "Lista os serviços da barbearia")]
        [SwaggerResponse(200, "Serviço da barbearia", typeof(List<ServiceOutput>))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> ListServices([FromQuery] int? id)
        {

            var command = new ListServicesCommand(GetUserId(), id, GetUserRole());

            var response = await _handler.SendCommand<ListServicesCommand, List<ServiceOutput>>(command);

            if (IsValidOperation())
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }
    }
}
