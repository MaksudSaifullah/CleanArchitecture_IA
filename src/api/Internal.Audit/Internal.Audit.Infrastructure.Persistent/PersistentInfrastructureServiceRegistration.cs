
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Infrastructure.Persistent.Repositories;
using Internal.Audit.Infrastructure.Persistent.Repositories.Countries;
using Internal.Audit.Infrastructure.Persistent.Repositories.Designations;
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
        services.AddScoped<ICountryCommandRepository, CountryCommandRepository>();
        services.AddScoped<ICountryQueryRepository>(s => new CountryQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IDesignationCommandRepository, DesignationCommandRepository>();
        services.AddScoped<IDesignationQueryRepository>(s => new DesignationQueryRepository(configuration.GetConnectionString("InternalAuditDb")));

        return services;
    }
}
