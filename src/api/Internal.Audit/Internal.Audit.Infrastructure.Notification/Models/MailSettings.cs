
namespace Internal.Audit.Infrastructure.Notification.Models;

public class MailSettings
{
    public MailSettings(string smtp, int port, string userMail, string password)
    {
        Smtp = smtp;
        Port = port;
        UserEmail = userMail;
        Password = password;
    }

    public string Smtp { get; set; } = null!;
    public int Port { get; set; }
    public string UserEmail { get; set; } = null!;
    public string Password { get; set; } = null!;
}
