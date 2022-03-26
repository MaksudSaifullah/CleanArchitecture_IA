
using Internal.Audit.Application.Models;

namespace Internal.Audit.Application.Contracts.Notifications;

public interface IMailService
{
    IMailService Setup(string sender, List<string> tos, List<string> ccs, bool htmlSupported);
    IMailService FormatSubject(string rawSubject, string pattern, Dictionary<string, string> variables);
    IMailService FormatBody(string rawBody, string pattern, Dictionary<string, string> variables);
    MailResponse Send();
    Task<MailResponse> SendAsync();
}
