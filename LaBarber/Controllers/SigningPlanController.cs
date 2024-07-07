using LaBarber.Application.Company.Boundaries;
using LaBarber.Application.Company.Commands;
using LaBarber.Application.SigningPlan.Boundaries;
using LaBarber.Application.SigningPlan.Commands.CreateSigningPlan;
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
    [SwaggerTag("Endpoints relacionados a planos da empresa, sendo necessário se autenticar")]
    public class SigningPlanController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public SigningPlanController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Master")]
        [SwaggerOperation(
            Summary = "Criar Plano de empresa",
            Description = "Cria um plano de empresa")]
        [SwaggerResponse(201, "Plano de empresa criada com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(IEnumerable<string>))]
        public async Task<IActionResult> CreateSigningPlan([FromBody] SigningPlanInput signingPlan)
        {
            var command = new CreateSigningPlanCommand(signingPlan);

            await _handler.SendCommand<CreateSigningPlanCommand, bool>(command);

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
