using LaBarber.Application.Barber.Boundaries;
using LaBarber.Application.Barber.Commands;
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
        public async Task<IActionResult> CreateBarberUnitManager([FromBody] CreateBarberInput input)
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
    }
}
