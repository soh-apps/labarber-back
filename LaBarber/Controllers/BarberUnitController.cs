using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands.CreateCompanyUser;
using LaBarber.Application.Company.Commands;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection.Metadata;
using LaBarber.Domain.Base.Communication;
using LaBarber.Application.BarberUnit.Boundaries;
using LaBarber.Application.BarberUnit.Commands;

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

        [HttpPost("CreateBarberUnit")]
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
    }
}
