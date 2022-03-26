
using Internal.Audit.Application.Contracts.Notifications;
using Internal.Audit.Application.Models;
using Internal.Audit.Infrastructure.Notification.Models;
using System.Net;
using System.Net.Mail;

namespace Internal.Audit.Infrastructure.Notification.Services;

public class MailService : IMailService
{
    private readonly MailSettings _mailsettings;
    private SenderSettings _senderSettings;

    public MailService(MailSettings mailsettings)
    {
        this._mailsettings = mailsettings;
        _senderSettings = new SenderSettings
        {
            Body = string.Empty,
            Subject = string.Empty,
            Sender = string.Empty,
            TOs = new List<string>(),
            CCs = new List<string>(),
            HtmlSupported = false
        };
    }

    /// <summary>
    /// This will send mail after initial setup
    /// </summary>
    /// <returns>MailResponse with response code and message</returns>
    public MailResponse Send()
    {
        using (var smtpClient = new SmtpClient(_mailsettings.Smtp, _mailsettings.Port))
            try
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_mailsettings.UserEmail, _mailsettings.Password);
                smtpClient.EnableSsl = true;
                var message = new MailMessage
                {
                    IsBodyHtml = _senderSettings.HtmlSupported,
                    From = new MailAddress(_senderSettings.Sender),
                    Subject = _senderSettings.Subject,
                    Body = _senderSettings.Body
                };
                _senderSettings.TOs.ForEach(r => { message.To.Add(r); });
                _senderSettings.CCs.ForEach(r => { message.CC.Add(r); });

                smtpClient.Send(message);
                return new MailResponse(true, 250, "Mail sent successfully");

            }
            catch (Exception exception)
            {
                return new MailResponse(false, 421, "Sent failed! " + exception.Message);
            }

    }

    /// <summary>
    /// This will send mail after initial setup in asynchronous way
    /// </summary>
    /// <returns>MailResponse with response code and message</returns>
    public async Task<MailResponse> SendAsync()
    {
        using (var smtpClient = new SmtpClient(_mailsettings.Smtp, _mailsettings.Port))
            try
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_mailsettings.UserEmail, _mailsettings.Password);
                smtpClient.EnableSsl = true;
                var message = new MailMessage
                {
                    IsBodyHtml = _senderSettings.HtmlSupported,
                    From = new MailAddress(_senderSettings.Sender),
                    Subject = _senderSettings.Subject,
                    Body = _senderSettings.Body
                };
                _senderSettings.TOs.ForEach(r => { message.To.Add(r); });
                _senderSettings.CCs.ForEach(r => { message.CC.Add(r); });

                await smtpClient.SendMailAsync(message);
                return new MailResponse(true, 250, "Mail sent successfully");

            }
            catch (Exception exception)
            {
                return new MailResponse(false, 421, "Sent failed! " + exception.Message);
            }
    }

    /// <summary>
    /// Construct Mail body from rawBody string to actual email body based on provided pattern and variable dictionary
    /// Input: Hi ##Name##, How are you?
    /// Output: Hi David, How are you?
    /// </summary>
    /// <param name="rawBody">Raw configured mail body pattern, from above example: Hi ##Name##, How are you?</param>
    /// <param name="pattern">Pattern enclosed string which need to be replaced with variables, from above example: ##</param>
    /// <param name="variables">key value pair, key (enclosed with pattern) will be replaced by value, from above example:  {Name, David}</param>
    /// <returns>Constructed actual body</returns>
    public IMailService FormatBody(string rawBody, string pattern, Dictionary<string, string> variables)
    {
        _senderSettings.Body = Construct(rawBody, pattern, variables);

        return this;
    }


    /// <summary>
    /// Construct Mail subject from rawSubject string to actual email subject based on provided pattern and variable dictionary
    /// Input: From ##Company##: OTP
    /// Output: From ABC Inc.: OTP
    /// </summary>
    /// <param name="rawSubject">Raw configured mail subject pattern, from above example: From ##Company##: OTP</param>
    /// <param name="pattern">Pattern enclosed string which need to be replaced with variables, from above example: ##</param>
    /// <param name="variables">key value pair, key (enclosed with pattern) will be replaced by value, from above example:  {Company, ABC Inc.}</param>
    /// <returns>Constructed actual subject</returns>
    public IMailService FormatSubject(string rawSubject, string pattern, Dictionary<string, string> variables)
    {
        _senderSettings.Subject = Construct(rawSubject, pattern, variables);

        return this;
    }

    /// <summary>
    /// Mail settings with sender, receivers (both TO and CC) and whether mail supports HTML body or not
    /// </summary>
    /// <param name="sender">From whome the mail will be sent</param>
    /// <param name="tos">To whome the mail will be sent</param>
    /// <param name="ccs">Carbon Copied (CC) reecivers who will also receive the mail</param>
    /// <param name="htmlSupported">whether mail body is HTML supported or not</param>
    /// <returns></returns>
    public IMailService Setup(string sender, List<string> tos, List<string> ccs, bool htmlSupported)
    {
        _senderSettings.Sender = sender;
        _senderSettings.TOs = tos;
        _senderSettings.CCs = ccs;
        _senderSettings.HtmlSupported = htmlSupported;
        return this;
    }

    private static string Construct(string rawString, string pattern, Dictionary<string, string> variables)
    {
        foreach (var item in variables)
            rawString = rawString.Replace(pattern + item.Key + pattern, item.Value);
        return rawString.Replace("&lt;", "<").Replace("&gt;", ">")
            .Replace("%3C", "<").Replace("%3E", ">");
    }
}
