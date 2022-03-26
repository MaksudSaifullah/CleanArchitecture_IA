
namespace Internal.Audit.Infrastructure.Notification.Models;

public class SenderSettings
{
    public List<string> TOs { get; set; } = null!;
    public List<string> CCs { get; set; } = null!;
    public string Sender { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
    public bool HtmlSupported { get; set; } = true;
}
