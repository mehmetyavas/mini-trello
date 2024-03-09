using System.Net;
using System.Net.Mail;
using Core.Data.Dto.Email;
using Core.Data.Enum;
using Core.Extensions;
using Core.Utilities.Helpers;

namespace WebAPI.Business.Mail;

public class MailManager
{
    private SmtpClient Client { get; }
    private string FromMail { get; }

    public MailManager()
    {
        var mailCreds = AppConfig.MailCreds;

        FromMail = mailCreds.Email;

        Client = new SmtpClient
        {
            Credentials = new NetworkCredential(mailCreds!.Email, mailCreds.Password),
            EnableSsl = true,
            Host = mailCreds!.Host,
            Port = mailCreds!.Port,
        };
    }


    public async Task SendRegisterMailAsync(string email, string verifyToken,
        CancellationToken cancellationToken = default)
    {
        var rootPath = AppConfig.WebRootPath;

        var register = AppConfig.MailBody.Register;

        var htmlFilePath = Path.Combine(rootPath, "Template", "index.html");

        var template = await File.ReadAllTextAsync(htmlFilePath, cancellationToken);


        var mail = new EmailDto
        {
            Email = email,
            Subject = register.Subject,
            Body = template
                .Replace("{{title}}", register.Subject)
                .Replace("{{content-body}}", MailKeys.RegisterBody.Localize())
                .Replace("{{action-text}}", MailKeys.RegisterActionText.Localize())
                .Replace("{{action-redirect}}", string.Format(register.Body, verifyToken))
                .Replace("{{baseUrl}}", AppConfig.AppInfo.BaseUrl)
                .Replace("{{appUrl}}", AppConfig.AppInfo.AppUrl)
        };

        await SendMailAsync(mail, cancellationToken);
    }

    public async Task SendLoginCodeAsync(string email, string loginCode,
        CancellationToken cancellationToken = default)
    {
        var rootPath = AppConfig.WebRootPath;

        var register = AppConfig.MailBody.Register;

        var htmlFilePath = Path.Combine(rootPath, "Template", "loginCode.html");

        var template = await File.ReadAllTextAsync(htmlFilePath, cancellationToken);


        var mail = new EmailDto
        {
            Email = email,
            Subject = register.Subject,
            Body = template
                .Replace("{{title}}", register.Subject)
                .Replace("{{content-body}}", loginCode)
                .Replace("{{baseUrl}}", AppConfig.AppInfo.BaseUrl)
                .Replace("{{appUrl}}", AppConfig.AppInfo.AppUrl)
        };

        await SendMailAsync(mail, cancellationToken);
    }

    private async Task MailBulkAsync(List<EmailDto> emails,
        CancellationToken cancellationToken = default)
    {
        foreach (var email in emails)
        {
            await Task.Run(() =>
            {
                var message = new MailMessage(
                    from: FromMail,
                    to: email.Email,
                    subject: email.Subject,
                    body: email.Body
                );
                message.IsBodyHtml = true;
                Client.Send(message);
            }, cancellationToken);
        }

        Client.Dispose();
    }

    public async Task SendMailAsync(EmailDto email,
        CancellationToken cancellationToken = default)
    {
        var mail = new MailMessage(
            from: FromMail,
            to: email.Email,
            subject: email.Subject,
            body: email.Body
        );
        mail.IsBodyHtml = true;
        await Client.SendMailAsync(mail, cancellationToken);
        Client.Dispose();
    }
}