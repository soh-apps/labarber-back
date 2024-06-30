using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands;
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
    [SwaggerTag("Endpoints relacionados a unidades de barbearia, sendo necessário se autenticar")]
    public class BarberUnitController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public BarberUnitController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(
            Summary = "Criar Barbearia",
            Description = "Cria uma barbearia vinculada a empresa do usuário administrador")]
        [SwaggerResponse(201, "Barbearia criada com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> CreateBarberUnit(CreateBarberUnitInput barberUnit)
        {
            barberUnit.SetUserId(GetUserId());
            barberUnit.SetUserRole(GetUserRole());
            var command = new CreateBarberUnitCommand(barberUnit);

            await _handler.SendCommand<CreateBarberUnitCommand, bool>(command);

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
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(
            Summary = "Atualizar dados da barbearia",
            Description = "Atualiza dos dados de uma barbearia vinculada a empresa do usuário administrador")]
        [SwaggerResponse(200, "Barbearia atualizado com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> UpdateBarberUnit(UpdateBarberUnitInput barberUnit)
        {
            barberUnit.SetUserId(GetUserId());
            barberUnit.SetUserRole(GetUserRole());
            var command = new UpdateBarberUnitCommand(barberUnit);

            await _handler.SendCommand<UpdateBarberUnitCommand, bool>(command);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Master,Admin")]
        [SwaggerOperation(
            Summary = "Obter dados de uma barbearia",
            Description = "Lista os dados da barbearia informada.")]
        [SwaggerResponse(200, "Informações da barberia retornadas com sucesso", typeof(BarberUnitOutput))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetBarberUnitById(int id)
        {
            var command = new GetBarberUnitCommand(GetUserId(), GetUserRole(), id);

            var barberUnit = await _handler.SendCommand<GetBarberUnitCommand, BarberUnitOutput>(command);

            if (IsValidOperation())
            {
                return Ok(barberUnit);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("GetBarberUnitsByCompany")]
        [Authorize(Roles = "Master,Admin")]
        [SwaggerOperation(
            Summary = "Listar barbearias da empresa",
            Description = "Lista as barbearias de uma empresa informada, ou da empresa do usuário administrador logado.")]
        [SwaggerResponse(200, "Barbearias listadas com sucesso", typeof(IEnumerable<BarberUnitOutput>))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetBarberUnitsByCompany([FromQuery]int? id)
        {
            var command = new GetBarberUnitsByCompanyCommand(GetUserId(), GetUserRole(), id);

            var barberUnits = await _handler.SendCommand<GetBarberUnitsByCompanyCommand, IEnumerable<BarberUnitOutput>>(command);

            if (IsValidOperation())
            {
                return Ok(barberUnits);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }
    }
}
