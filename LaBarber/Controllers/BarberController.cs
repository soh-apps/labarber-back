using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands;
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
    public class BarberController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public BarberController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerResponse(201, "Usuário da barbearia criada com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> CreateBarber([FromBody] CreateBarberInput input)
        {
            input.SetUserId(GetUserId());
            input.SetUserRole(GetUserRole());

            var command = new CreateBarberCommand(input);

            await _handler.SendCommand<CreateBarberCommand, bool>(command);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("GetAllBarbers")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "Listar Barbeiros",
            Description = "Lista os barbeiros de acordo com unidade da barbearia selecionada ou pertencente ao usuário")]
        [SwaggerResponse(200, "Lista os barbeiros", typeof(List<BarberOutput>))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetAllBarbers([SwaggerParameter("Id da barbearia")][FromQuery] int? barberUnitId)
        {

            var command = new GetAllBarbersCommand(GetUserId(), barberUnitId, GetUserRole());

            var barbers = await _handler.SendCommand<GetAllBarbersCommand, List<BarberOutput>>(command);

            if (IsValidOperation())
            {
                return Ok(barbers);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("GetBarber/{id}")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "Get Barbeiro",
            Description = "Pega as informações do barbeiro")]
        [SwaggerResponse(200, "Lista os barbeiros", typeof(BarberOutput))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetBarber([SwaggerParameter("Id do barbeiro")][FromRoute] int id)
        {

            var command = new GetBarberByIdCommand(id);

            var barbers = await _handler.SendCommand<GetBarberByIdCommand, BarberOutput>(command);

            if (IsValidOperation())
            {
                return Ok(barbers);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin, Manager")]
        [SwaggerOperation(
            Summary = "Atualiza Barbeiro",
            Description = "Atualiza as informações do barbeiro")]
        [SwaggerResponse(204, "Usuário da barbearia atualizado com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> UpdateBarber([FromBody] UpdateBarberInput input)
        {
            input.SetUserId(GetUserId());
            input.SetUserRole(GetUserRole());

            var command = new UpdateBarberCommand(input);

            await _handler.SendCommand<UpdateBarberCommand, bool>(command);

            if (IsValidOperation())
            {
                return NoContent();
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }
    }
}
