using LaBarber.Application.AppUser.Boundaries;
using LaBarber.Application.AppUser.Commands.Login;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LaBarber.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AppUserController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public AppUserController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginInput input)
        {
            var command = new LoginCommand(input);
            await _handler.SendCommand<LoginCommand, bool>(command);
            if (IsValidOperation())
            {
                return Ok();
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }
    }
}
