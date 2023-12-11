using MailKit.Net.Smtp;
using MimeKit;
using Vemo.Application.Common.Interfaces;

namespace Vemo.Infrastructure.Services;

/// <summary>
///  EmailService
/// </summary>
public class EmailService : IEmailService
{
    /// <summary>
    /// SendEmailAsync
    /// </summary>
    /// <param name="toEmail"></param>
    /// <param name="userName"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    public async Task SendEmailAsync(string toEmail, string userName, string subject, string body, CancellationToken cancellationToken)
    {
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress("Vemo App", "mail.vemo.app@gmail.com"));
        email.To.Add(new MailboxAddress(userName, toEmail));
        email.Subject = subject;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = body
        };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync("smtp.gmail.com", 587, false, cancellationToken);
        await smtp.AuthenticateAsync("mail.vemo.app@gmail.com", "lbwxihiiiaxctwfw", cancellationToken);
        await smtp.SendAsync(email, cancellationToken);
        await smtp.DisconnectAsync(true, cancellationToken);
    }
}