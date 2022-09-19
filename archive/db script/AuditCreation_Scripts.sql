
CREATE TABLE [seven].[Audit]
(
	[Id] [uniqueidentifier] NOT NULL primary key default newsequentialid(),
	[AuditPlanId] [uniqueidentifier] NOT NULL foreign key references [seven].[AuditPlan](Id),
	[AuditTypeId] [uniqueidentifier] NOT NULL foreign key references [common].[AuditType](Id),
	[CountryId] [uniqueidentifier] NOT NULL foreign key references [common].[Country](Id),
	[Name] [nvarchar](50) NOT NULL,
	--[Type] [int] NOT NULL,
	[AuditYear] Int NOT NULL,
	[PeriodFrom] [datetime] NOT NULL,
	[PeriodTo] [datetime] NOT NULL,
	--[ReviewFrom] [datetime] NOT NULL,
	--[ReviewTo] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL default(0),
)

--CREATE TABLE [seven].[AuditBranch](
--	[Id] [uniqueidentifier] NOT NULL primary key default newsequentialid(),
--	[AuditId] [uniqueidentifier] NOT NULL foreign key references [seven].[Audit](Id) ,
--	[CountryId] [uniqueidentifier] NOT NULL foreign key references [common].[Country](Id),
--	[BranchId] [uniqueidentifier] NOT NULL,
--	[CreatedBy] [nvarchar](10) NOT NULL,
--	[CreatedOn] [datetime] NOT NULL,
--	[UpdatedBy] [nvarchar](10) NULL,
--	[UpdatedOn] [datetime] NULL,
--	[ReviewedBy] [nvarchar](10) NULL,
--	[ReviewedOn] [datetime] NULL,
--	[ApprovedBy] [nvarchar](10) NULL,
--	[ApprovedOn] [datetime] NULL,
--	[IsDeleted] [bit] NOT NULL default(0),
--)


CREATE TABLE [seven].[AuditSchedule](
	[Id] [uniqueidentifier] NOT NULL primary key default newsequentialid(),
	[AuditId] [uniqueidentifier] NOT NULL foreign key references [seven].[Audit](Id),
	[Approver] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[TeamLeader] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	--[AuditEffectiveFrom] [datetime] NOT NULL,
	--[AuditEffectiveTo] [datetime] NOT NULL,
	[ScheduleStartDate] [datetime] NOT NULL,
	[ScheduleEndDate] [datetime] NOT NULL,
	--[Approver] [nvarchar](250) NOT NULL,
	--[TeamLeader] [nvarchar](250) NOT NULL,
	[AuditInitiationDate] [datetime] NOT NULL,
	[PlanningAndScopingStartDate] [datetime] NOT NULL,
	[PlanningAndScopingEndDate] [datetime] NOT NULL,
	[FieldWorkStartDate] [datetime] NOT NULL,
	[FieldWordEndDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [nchar](10) NOT NULL default(0),
 )


 CREATE TABLE [seven].[AuditScheduleBranch]
 (
	[Id] [uniqueidentifier] NOT NULL primary key default newsequentialid(),
	[AuditScheduleId] [uniqueidentifier] NOT NULL foreign key references [seven].[AuditSchedule](Id),
	[CountryId] [uniqueidentifier] NOT NULL foreign key references common.Country(Id),
	[BranchId] [uniqueidentifier] NOT NULL foreign key references common.[Branch](Id),  -- we need to create Branch table
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] bit NOT NULL default(0)
)


CREATE TABLE [seven].[AuditScheduleAuditor]
(
	[Id] [uniqueidentifier] NOT NULL primary key default newsequentialid(),
	[AuditScheduleId] [uniqueidentifier] NOT NULL foreign key references [seven].[AuditSchedule](Id),
	[AuditorId] [uniqueidentifier] NOT NULL foreign key references [security].[Employee](Id),
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](50) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](50) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] bit NOT NULL default(0)
)

CREATE TABLE [seven].[AuditScheduleRiskActionOwner](
	[Id] [uniqueidentifier] NOT NULL primary key default newsequentialid(),
	[AuditScheduleId] [uniqueidentifier] NOT NULL  foreign key references [seven].[AuditSchedule](Id),
	[BranchId] [uniqueidentifier] NOT NULL foreign key references common.[Branch](Id),  -- we need to create Branch table,
	[RiskOwerId] [nvarchar](10) NOT NULL,
	[ActionOwerId] [nvarchar](10) NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] bit NOT NULL default(0)
)