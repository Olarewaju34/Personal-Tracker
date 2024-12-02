namespace PT.Application.Abstraction.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<string> toEmails,string subject,string content,bool isBulk,CancellationToken cancellationToken);
    }
}
