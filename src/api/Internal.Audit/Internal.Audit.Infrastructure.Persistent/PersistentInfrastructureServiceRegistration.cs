
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Infrastructure.Persistent.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Internal.Audit.Infrastructure.Persistent;

public static class PersistentInfrastructureServiceRegistration
{
    public static IServiceCollection AddPersistentInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<InternalAuditContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("InternalAuditDb")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncCommandRepository<>), typeof(CommandRepositoryBase<>));
        services.AddScoped(typeof(IAsyncQueryRepository<>), typeof(QueryRepositoryBase<>));
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IUserQueryRepository>(s => new UserQueryRepository(configuration.GetConnectionString("InternalAuditDb")));

        return services;
    }
}
