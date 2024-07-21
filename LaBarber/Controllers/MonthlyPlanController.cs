using LaBarber.API.Controllers;
using LaBarber.Application.MonthlyPlan.Boundaries;
using LaBarber.Application.MonthlyPlan.Commands;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LaMonthlyPlan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MonthlyPlan : BaseController
    {
        private readonly IMediatorHandler _handler;
        public MonthlyPlan(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(
            Summary = "Criar plano de cliente",
            Description = "Criar plano de cliente")]
        [SwaggerResponse(201, "Plano criado com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> Create([FromBody] CreateMonthlyPlanInput input)
        {
            input.SetUserId(GetUserId());

            var command = new CreateMonthlyPlanCommand(input);

            await _handler.SendCommand<CreateMonthlyPlanCommand, bool>(command);

            if (IsValidOperation())
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("GetAllMonthlyPlan")]
        [Authorize(Roles = "Admin, Manager, Barber")]
        [SwaggerOperation(
            Summary = "Listar planos",
            Description = "Lista planos")]
        [SwaggerResponse(200, "Lista os planos", typeof(List<MonthlyPlanOutput>))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetAllMonthlyPlans()
        {
            var command = new GetAllMonthlyPlansCommand(GetUserId(), GetUserRole());

            var MonthlyPlans = await _handler.SendCommand<GetAllMonthlyPlansCommand, List<MonthlyPlanOutput>>(command);

            if (IsValidOperation())
            {
                return Ok(MonthlyPlans);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin, Manager, Barber")]
        [SwaggerOperation(
            Summary = "Get entidade",
            Description = "Obtém a entidade por id")]
        [SwaggerResponse(200, "Lista os barbeiros", typeof(MonthlyPlanOutput))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> GetMonthlyPlan([SwaggerParameter("Id da entidade")][FromRoute] int id)
        {
            var command = new GetMonthlyPlanByIdCommand(id, GetUserId(), GetUserRole());

            var MonthlyPlans = await _handler.SendCommand<GetMonthlyPlanByIdCommand, MonthlyPlanOutput>(command);

            if (IsValidOperation())
            {
                return Ok(MonthlyPlans);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(
            Summary = "Atualiza entidade",
            Description = "Atualiza as informações da entidade")]
        [SwaggerResponse(204, "Entidade atualizada com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> UpdateMonthlyPlan([FromBody] UpdateMonthlyPlanInput input)
        {
            input.SetUserId(GetUserId());

            var command = new UpdateMonthlyPlanCommand(input);

            await _handler.SendCommand<UpdateMonthlyPlanCommand, bool>(command);

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
