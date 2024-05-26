using LaBarber.Domain.Base.Email;
using LaBarber.Domain.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace LaBarber.Infra.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _sendGridApiKey;
        public Secrets _secrets { get; }
        public EmailSender(IOptions<Secrets> secrets)
        {
            _sendGridApiKey = secrets.Value.SendGridApiKey;
            _secrets = secrets.Value;
        }
        public async Task<bool> SendEmailAsync(EmailMessage email)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _secrets.FromAddress,
                Name = _secrets.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }
    }
}