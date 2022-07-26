using Internal.Audit.Infrastructure.MQService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.MQService;

public static class InfrastructureMQServiceRegistration
{
    public static IServiceCollection AddInfrastructureMQServices(this IServiceCollection services, IConfiguration configuration)
    {
 
        services.AddScoped<IBrokerService>(s => new BrokerService(configuration["Broker:BrokerAddress"]));
        return services;
    }
}

