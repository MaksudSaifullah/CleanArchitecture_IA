﻿using Internal.Audit.Domain.Common;
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
    public DbSet<RoleAction> RoleActions { get; set; }
    public DbSet<RoleFeature> RoleFeatures { get; set; }
    public DbSet<RoleModule> RoleModules { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<PasswordPolicy> PasswordPolicies { get; set; }
    public DbSet<SessionPolicy> SessionPolicies { get; set; }
    public DbSet<UserLockingPolicy> UserLockingPolicies { get; set; }
    public DbSet<AuditModule> AuditModule { get; set; }
    public DbSet<FeatureAction> FeatureActions { get; set; }
    public DbSet<AuditFeature> AuditFeature { get; set; }
    public DbSet<AuditAction> AuditAction { get; set; }
    public DbSet<RiskProfile> RiskProfiles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<CommonValueAndType> CommonValueAndTypes { get; set; }
    public DbSet<DashBoardBase> Dashboards { get; set; }
    public DbSet<ModulewiseRolePriviliege> ModulewiseRolePrivilieges { get; set; }
    public DbSet<ModuleFeature> ModuleFeatures { get; set; }
    public DbSet<EmailType> EmailTypes { get; set; }
    public DbSet<EmailConfiguration> EmailConfigurations { get; set; }
    public DbSet<TopicHead> TopicHeads { get; set; }
    public DbSet<RiskAssessment> RiskAssessments { get; set; }
    public DbSet<RiskCriteria> RiskCriterias { get; set; }
    public DbSet<DocumentSource> DocumentSources { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<UserPasswordReset> UserPasswordResets { get; set; }
    public DbSet<AuditType> AuditTypes { get; set; }
    public DbSet<AuditCreation> AuditCreations { get; set; }
    public DbSet<WeightScore> WeightScores { get; set; }
    public DbSet<AuditFrequency> AuditFrequencies { get; set; }
    public DbSet<Questionnaire> Questionnaires { get; set; }
    public DbSet<DataRequestQueueService> DataRequestQueueServices { get; set; }
    public DbSet<AmbsDataSync> AmbsDataSyncs { get; set; }
    public DbSet<AuditPlan> AuditPlans { get; set; }
    public DbSet<TestStep> TestSteps { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<AuditSchedule> AuditSchedules { get; set; }
    public DbSet<AuditScheduleParticipants> AuditScheduleParticipants { get; set; }
    public DbSet<AuditScheduleBranch> AuditScheduleBranches { get; set; }
    public DbSet<WorkPaper> WorkPapers { get; set; }
    public DbSet<RiskAssesmentDataManagementLog> RiskAssesmentDataManagementLogs { get; set; }
    public DbSet<RiskAssesmentDataManagement> RiskAssesmentDataManagements { get; set; }
    public DbSet<UploadDocument> UploadDocuments { get; set; }
    public DbSet<UploadedDocumentsNotify> UploadedDocumentsNotifys { get; set; }
    public DbSet<Issue> Issues { get; set; }
    //public DbSet<IssueOwner> IssueOwners { get; set; }
    public DbSet<RiskAssesmentConsolidateData> RiskAssesmentConsolidateDatas { get; set; }

    public DbSet<ClosingMeetingMinute> ClosingMeetingMinutes { get; set; }
    public DbSet<ClosingMeetingPresent> ClosingMeetingPresents { get; set; }
    public DbSet<ClosingMeetingSubject> ClosingMeetingSubjects { get; set; }
    public DbSet<ClosingMeetingApology> ClosingMeetingApologies { get; set; }
    public DbSet<Checklist> Checklists { get; set; }
    public DbSet<ChecklistTopic> ChecklistTopics { get; set; }
    public DbSet<ChecklistTopicDetail> ChecklistTopicDetails { get; set; }
    public DbSet<AuditScheduleConfigurationOwner> AuditScheduleConfigurationOwners { get; set; }
    public DbSet<AuditConfigMileStone> AuditConfigMileStones { get; set; }

    public DbSet<NotificationToAuditee> NotificationToAuditees { get; set; }
    public DbSet<NotifedUsersTo> NotifedUsersTos { get; set; }
    public DbSet<NotifedUsersCC> NotifedUsersCCs { get; set; }
    public DbSet<NotifedUsersBCC> NotifedUsersBCCs { get; set; }
    public DbSet<IssueValidation> IssueValidations { get; set; }
    public DbSet<IssueValidationActionPlan> IssueValidationActionPlans { get; set; }
    public DbSet<IssueValidationDesignEffectiveNessTestDetail> IssueValidationDesignEffectiveNessTestDetails { get; set; }
    public DbSet<IssueValidationTestSheet> IssueValidationTestSheets { get; set; }
    public DbSet<IssueValidationEvidenceDetail> IssueValidationEvidenceDetails { get; set; }

    public DbSet<Internal.Audit.Domain.Entities.ProcessAndControlAudit.RiskCriteria> PC_RiskCriterias { get; set; }

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
