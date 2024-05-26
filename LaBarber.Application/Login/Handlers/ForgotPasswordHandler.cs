using System.Text;
using LaBarber.Application.Login.Boundaries;
using LaBarber.Application.Login.Commands.ForgotPassword;
using LaBarber.Application.Login.UseCase;
using LaBarber.Application.Token;
using LaBarber.Domain.Base.Communication;
using LaBarber.Domain.Base.Email;
using LaBarber.Domain.Base.Messages.Notification;
using MediatR;

namespace LaBarber.Application.Login.Handlers
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IEmailSender _emailSender;
        private readonly ITokenUseCase _tokenUseCase;

        public ForgotPasswordHandler(IMediatorHandler mediatorHandler, ILoginUseCase loginUseCase,
         ITokenUseCase tokenUseCase, IEmailSender emailSender)
        {
            _mediatorHandler = mediatorHandler;
            _loginUseCase = loginUseCase;
            _tokenUseCase = tokenUseCase;
            _emailSender = emailSender;
        }

        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            if (request.IsValid())
            {
                var credential = await _loginUseCase.GetCredentialByEmail(request.Input.Email);
                if (credential.Id > 0)
                {
                    var code = _tokenUseCase.GenerateRecoveryCode();
                    await _loginUseCase.AddRecoveryCode(credential.Id, code);
                    var email = MontoCorpoEmail(code, credential.Username, credential.Email);

                    var sucess = await _emailSender.SendEmailAsync(email);

                    if (sucess)
                    {
                        return sucess;
                    }
                    else
                    {
                        await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, "ocorreu um erro ao recuperar senha"));
                    }

                }
                else
                {
                    await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, "usuario não encontrado"));
                    return false;
                }
            }

            foreach (var error in request.ValidationResult.Errors)
            {
                await _mediatorHandler.PublishNotification(new DomainNotification(request.MessageType, error.ErrorMessage));
            }
            return false;

        }

        private static EmailMessage MontoCorpoEmail(string code, string username, string userEmail)
        {
            var corpoEmail = new StringBuilder();
            corpoEmail.AppendLine($"Ola: {username}. Seu codigo para recurepar a senha é:  {code}");
            corpoEmail.AppendLine("");

            var email = new EmailMessage
            {
                Subject = "Recuperação de senha",
                To = userEmail,
                Body = corpoEmail.ToString()
            };

            return email;
        }
    }
}