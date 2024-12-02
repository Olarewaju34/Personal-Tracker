using Microsoft.Extensions.Options;
using PT.Application.Abstraction.Email;
using System.Net;
using System.Net.Mail;

namespace PT.Infratructure.Email
{
    public class EmailService(IOptions<EmailSettings> options) : IEmailService
    {
        private readonly EmailSettings _emailSettings = options.Value;
        public async Task SendEmailAsync(List<string> toEmails, string subject, string content, bool isBulk, CancellationToken cancellationToken)
        {
            using var smptClient = new SmtpClient(isBulk ? _emailSettings.BulkSmtpHost : _emailSettings.SmtpHost, _emailSettings.SmtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(_emailSettings.UserName, _emailSettings.Password)
            };
            var mailMessage = new MailMessage()
            {
                Subject = subject,
                SubjectEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true,
                From = new MailAddress(_emailSettings.From, _emailSettings.FromName),
                Body = content
            };
            foreach (var email in toEmails)
            {
                mailMessage.To.Add(email);
            }
            await smptClient.SendMailAsync(mailMessage);
        }
    }
}
