using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.ForgotPassword;
using LaBarber.Application.Login.Commands.Login;
using LaBarber.Application.Login.Commands.RecoverPassword;
using LaBarber.Application.Login.Commands.RefreshToken;
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
    [AllowAnonymous]
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

        [HttpPost("RefreshToken")]
        [SwaggerResponse(200, "Login realizado com sucesso", typeof(LoginOutput))]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenInput input)
        {
            var command = new RefreshTokenCommand(input);
            var response = await _handler.SendCommand<RefreshTokenCommand, LoginOutput>(command);
            if (IsValidOperation())
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpPost("ForgotPassword")]
        [SwaggerResponse(200, "E-mail foi enviado para o usuario com o codigo")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordInput input)
        {
            var command = new ForgotPasswordCommand(input);

            await _handler.SendCommand<ForgotPasswordCommand, bool>(command);

            if (IsValidOperation())
            {
                return Ok();
            }
            else
            {
                return BadRequest(GetMessages());
            }
        }

        [HttpPost("RecoverPassword")]
        [SwaggerResponse(200, "Senha alterada com sucesso")]
        [SwaggerResponse(400, "Erros de dominio", typeof(List<string>))]
        public async Task<IActionResult> RecoverPassword([FromBody] RecoverPasswordInput input)
        {
            var command = new RecoverPasswordCommand(input);

            await _handler.SendCommand<RecoverPasswordCommand, bool>(command);

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
