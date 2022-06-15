﻿
using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Infrastructure.Persistent.Repositories;
using Internal.Audit.Infrastructure.Persistent.Repositories.Countries;
using Internal.Audit.Infrastructure.Persistent.Repositories.Designations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Internal.Audit.Application.Contracts.Persistent.Roles;

using Internal.Audit.Infrastructure.Persistent.Repositories.Roles;
using Internal.Audit.Application.Contracts.Persistent.UserCountries;
using Internal.Audit.Infrastructure.Persistent.Repositories.UserCountries;
using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Infrastructure.Persistent.Repositories.AccessPrivilege;
using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Infrastructure.Persistent.Repositories.UserList;

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
        services.AddScoped<Application.Contracts.Persistent.IUserQueryRepository>(s => new Repositories.UserQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<ICountryCommandRepository, CountryCommandRepository>();
        services.AddScoped<ICountryQueryRepository>(s => new CountryQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IDesignationCommandRepository, DesignationCommandRepository>();
        services.AddScoped<IDesignationQueryRepository>(s => new DesignationQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
        services.AddScoped<IRoleQueryRepository>(s => new RoleQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IUserCountryCommandRepository, UserCountryCommandRepository>();
        services.AddScoped<IUserCountryQueryRepository>(s => new UserCountryQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IPasswordPolicyCommandRepository, PasswordPolicyCommandRepository>();
        services.AddScoped<IUserLockingPolicyCommandRepository, UserLockingPolicyCommandRepository>();
        services.AddScoped<ISessionPolicyCommandRepository, SessionPolicyCommandRepository>();
        services.AddScoped<IPasswordPolicyQueryRepository>(s => new PasswordPolicyQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IUserLockingPolicyQueryRepository>(s => new UserLockingPolicyQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<ISessionPolicyQueryRepository>(s => new SessionPolicyQueryRepository(configuration.GetConnectionString("InternalAuditDb")));

        services.AddScoped<IUserListCommandRepository, UserListCommandRepository>(); services.AddScoped<IUserListQueryRepository>(s => new UserListQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IUpdateEmployeeCommandRepository, UpdateEmployeeCommandRepository>();
        services.AddScoped<IUpdateUserCountryCommandRepository, UpdateUserCountryCommandRepository>();
        services.AddScoped<IUpdateUserRoleCommandRepository, UpdateUserRoleCommandRepository>();


        return services;
    }
}
