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
    public class BarberUnitController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public BarberUnitController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
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
        [SwaggerResponse(200, "Informações da barberia retornadas com sucesso", typeof(BarberUnitOutput))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetBarberUnitById(int id)
        {
            var command = new GetBarberUnitCommand(GetUserId(), GetUserRole(), id);

            var barberUnits = await _handler.SendCommand<GetBarberUnitCommand, BarberUnitOutput>(command);

            if (IsValidOperation())
            {
                return Ok(barberUnits);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("GetBarberUnitsByCompany/{id}")]
        [Authorize(Roles = "Master,Admin")]
        [SwaggerResponse(200, "Barbearias listadas com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetBarberUnitsByCompany(int id)
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
