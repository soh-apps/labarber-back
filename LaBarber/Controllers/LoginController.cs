using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.Login;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LaBarber.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoginController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public LoginController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost]
        [SwaggerResponse(200, "Login realizado com sucesso", typeof(LoginOutput))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> Login([FromBody] LoginInput input)
        {
            var command = new LoginCommand(input);
            var response = await _handler.SendCommand<LoginCommand, LoginOutput>(command);
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
