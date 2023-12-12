namespace Vemo.Application.Common.Interfaces;

/// <summary>
/// IEmailService
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// SendEmailAsync
    /// </summary>
    /// <param name="toEmail"></param>
    /// <param name="userName"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task SendEmailAsync(string toEmail, string userName, string subject, string body, CancellationToken cancellationToken);
}