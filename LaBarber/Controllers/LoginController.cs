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
    [SwaggerTag("Endpoints relacionados ao login")]
    public class LoginController : BaseController
    {
        private readonly IMediatorHandler _handler;
        public LoginController(INotificationHandler<DomainNotification> notificationHandler, IMediatorHandler handler) : base(notificationHandler)
        {
            _handler = handler;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Login",
            Description = "Autentica o usuário e retorna seu perfil")]
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
        [SwaggerOperation(
            Summary = "Atualizar token",
            Description = "Gera um novo token para o usuário através do refresh token evitando que o usuário tenha que se autenticar novamente")]
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
        [SwaggerOperation(
            Summary = "Esqueceu a senha",
            Description = "Envia um e-mail com o código de recuperação de senha")]
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
        [SwaggerOperation(
            Summary = "Recuperar senha",
            Description = "Altera a senha do usuário com a senha recebida e o código que o usuário recebeu por e-mail")]
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
