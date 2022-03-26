
using Internal.Audit.Application.Contracts.Notifications;
using Internal.Audit.Infrastructure.Notification.Models;
using Internal.Audit.Infrastructure.Notification.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Internal.Audit.Infrastructure.Notification;

public static class InfrastructureNotificationsServiceRegistration
{
    public static IServiceCollection AddInfrastructureNotificationsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IMailService>(s => new MailService(
                                    new MailSettings(configuration["MailSettings:Smtp"],
                                    int.Parse(configuration["MailSettings:Port"]),
                                    configuration["MailSettings:UserEmail"],
                                    configuration["MailSettings:Password"])));

        return services;
    }
}
