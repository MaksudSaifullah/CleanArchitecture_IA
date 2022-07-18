using Internal.Audit.Domain.Common;
using Internal.Audit.Domain.Entities;
using Internal.Audit.Domain.Entities.common;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;
using Internal.Audit.Domain.Entities.Common;
using Internal.Audit.Domain.Entities.Config;
using Internal.Audit.Domain.Entities.config;
using Internal.Audit.Domain.Entities.BranchAudit;


namespace Internal.Audit.Infrastructure.Persistent;

public class InternalAuditContext: DbContext
{
    public InternalAuditContext(DbContextOptions<InternalAuditContext> options): base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<UserCountry> UserCountries { get; set; }
    public DbSet<Designation> Designations { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<PasswordPolicy> PasswordPolicies { get; set; }
    public DbSet<SessionPolicy> SessionPolicies { get; set; }
    public DbSet<UserLockingPolicy> UserLockingPolicies { get; set; }
    public DbSet<AuditModule> AuditModule { get; set; }
    public DbSet<AuditFeature> AuditFeature { get; set; }
    public DbSet<AuditAction> AuditAction { get; set; }
    public DbSet<RiskProfile> RiskProfiles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<CommonValueAndType> CommonValueAndTypes { get; set; }
    public DbSet<DashBoardBase> Dashboards { get; set; }
    public DbSet<ModulewiseRolePriviliege> ModulewiseRolePrivilieges { get; set; }
    public DbSet<ModuleFeature> ModuleFeatures { get; set; }
    public DbSet<EmailConfiguration> EmailConfigurations { get; set; }
    public DbSet<TopicHead> TopicHeads { get; set; }
    public DbSet<RiskAssessment> RiskAssessments { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                var memberInfo = property.PropertyInfo ?? (MemberInfo)property.FieldInfo;
                if (memberInfo == null) continue;
                var defaultValue = Attribute.GetCustomAttribute(memberInfo, typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                if (defaultValue == null) continue;
                if(defaultValue.Value != null)
                property.SetDefaultValueSql(defaultValue.Value.ToString());
            }
        }
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = "system"; //TODO: will change later
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = "system";
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
