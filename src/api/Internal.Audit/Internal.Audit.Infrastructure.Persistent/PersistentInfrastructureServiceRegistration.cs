
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
//using Internal.Audit.Application.Contracts.Persistent.UserCountries;
//using Internal.Audit.Infrastructure.Persistent.Repositories.UserCountries;
using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Infrastructure.Persistent.Repositories.AccessPrivilege;
using Internal.Audit.Application.Contracts.Persistent.UserList;
using Internal.Audit.Infrastructure.Persistent.Repositories.UserList;

using Internal.Audit.Application.Contracts.Persistent.AuditModules;
using Internal.Audit.Infrastructure.Persistent.Repositories.Modules;

using Internal.Audit.Application.Contracts.Persistent.AuditFeatures;
using Internal.Audit.Infrastructure.Persistent.Repositories.Features;

using Internal.Audit.Application.Contracts.Persistent.AuditActions;
using Internal.Audit.Infrastructure.Persistent.Repositories.Actions;
using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using Internal.Audit.Infrastructure.Persistent.Repositories.RiskProfiles;
using Internal.Audit.Infrastructure.Persistent.Repositories.CommonValueAndTypes;
using Internal.Audit.Application.Contracts.Persistent.CommonValueAndTypes;
using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Infrastructure.Persistent.Repositories.Dashboards;
using Internal.Audit.Application.Contracts.Persistent.UserRegistration;
using Internal.Audit.Infrastructure.Persistent.Repositories.UserRegistration;
using Internal.Audit.Application.Contracts.Persistent.ModulewiseRolePrivilege;
using Internal.Audit.Infrastructure.Persistent.Repositories.ModulewiseRolePrivilege;
using Internal.Audit.Application.Contracts.Persistent.ModuleFeature;
using Internal.Audit.Infrastructure.Persistent.Repositories.ModuleFeature;
using Internal.Audit.Application.Contracts.Persistent.RiskCriterias;
using Internal.Audit.Infrastructure.Persistent.Repositories.RiskCriterias;

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
        //services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        //services.AddScoped<IUserQueryRepository>(s => new UserQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<ICountryCommandRepository, CountryCommandRepository>();
        services.AddScoped<ICountryQueryRepository>(s => new CountryQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IDesignationCommandRepository, DesignationCommandRepository>();
        services.AddScoped<IDesignationQueryRepository>(s => new DesignationQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
        services.AddScoped<IRoleQueryRepository>(s => new RoleQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        //services.AddScoped<IUserCountryCommandRepository, UserCountryCommandRepository>();
        //services.AddScoped<IUserCountryQueryRepository>(s => new UserCountryQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IPasswordPolicyCommandRepository, PasswordPolicyCommandRepository>();
        services.AddScoped<IUserLockingPolicyCommandRepository, UserLockingPolicyCommandRepository>();
        services.AddScoped<ISessionPolicyCommandRepository, SessionPolicyCommandRepository>();
        services.AddScoped<IPasswordPolicyQueryRepository>(s => new PasswordPolicyQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IUserLockingPolicyQueryRepository>(s => new UserLockingPolicyQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<ISessionPolicyQueryRepository>(s => new SessionPolicyQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IAuditModuleQueryRepository>(s => new AuditModuleQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IAuditFeatureQueryRepository>(s => new AuditFeatureQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IAuditActionQueryRepository>(s => new AuditActionQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IRiskProfileCommandRepository, RiskProfileCommandRepository>();
        services.AddScoped<IRiskProfileQueryRepository>(s => new RiskProfileQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<ICommonValueAndTypeQueryRepository>(s => new CommonValueAndTypeQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IDashboardCommandRepository, DashboardCommandRepository>();
        services.AddScoped<IDashboardQueryRepository>(s => new DashboardQueryRepository(configuration.GetConnectionString("InternalAuditDb")));

        services.AddScoped<IUserListCommandRepository, UserListCommandRepository>();
        services.AddScoped<IUserListQueryRepository>(s => new UserListQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IUpdateEmployeeCommandRepository, UpdateEmployeeCommandRepository>();
        services.AddScoped<IUpdateUserCountryCommandRepository, UpdateUserCountryCommandRepository>();
        services.AddScoped<IUpdateUserRoleCommandRepository, UpdateUserRoleCommandRepository>();
        services.AddScoped<Application.Contracts.Persistent.UserList.IUserQueryRepository>(s => new Repositories.UserList.UserQueryRepository(configuration.GetConnectionString("InternalAuditDb")));


        services.AddScoped<IUserCountryCommandRepository, UserCountryCommandRepository>();
        services.AddScoped<IUserRoleCommandRepository, UserRoleCommandRepository>();
        services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<Application.Contracts.Persistent.UserRegistration.IUserQueryRepository>(s => new Repositories.UserRegistration.UserQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IUserRoleQueryRepository>(s => new UserRoleQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IUserCountryQueryRepository>(s => new UserCountryQueryRepository(configuration.GetConnectionString("InternalAuditDb")));
        services.AddScoped<IEmployeeQueryRepository>(s => new EmployeeQueryRepository(configuration.GetConnectionString("InternalAuditDb")));

        services.AddScoped<IModulewiseRolePrivilegeCommandRepository, ModulewiseRolePrivilegeCommandRepository>();
        services.AddScoped<IModulewiseRoleQueryRepository>(s => new ModulewiseRolePrivilegeQueryRepository(configuration.GetConnectionString("InternalAuditDb")));

        services.AddScoped<IModuleFeatureCommandRepository, ModuleFeatureCommandRepository>();
        services.AddScoped<IModuleFeatureQueryRepository>(s => new ModuleFeatureQueryRepository(configuration.GetConnectionString("InternalAuditDb")));


        services.AddScoped<IRiskCriteriaCommandRepository, RiskCriteriaCommandRepository>();
        services.AddScoped<IRiskCriteriaQueryRepository>(s => new RiskCriteriaQueryRepository(configuration.GetConnectionString("InternalAuditDb")));

        return services;
    }
}
