--7.9
CREATE TABLE [seven].[Issue](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[IssueId] [nvarchar](20) NOT NULL UNIQUE,
	[IssueTitle] [nvarchar](MAX) NOT NULL,
	[AuditId] [uniqueidentifier] NOT NULL, --FK of Audit
	[AuditScheduleId] [uniqueidentifier] NOT NULL, --FK for Schedule
	[BranchId] [uniqueidentifier] NOT NULL, --FK for Branch
	[IssueOwnerId] [BIGINT] NOT NULL FOREIGN KEY REFERENCES [security].[User](Id),
	[Policy] [nvarchar](MAX) NOT NULL,
	[ImpactTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [Config].[IssueImpactType](Id),
	[LikelihoodTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[IssueLikelihoodType](Id),
	[RatingTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[RatingType](Id),
	[TargetDate] [datetime] NOT NULL,
	[Details] [nvarchar](MAX) NOT NULL,
	[RootCause] [nvarchar](MAX) NOT NULL,
	[BusinessImpact] [nvarchar](MAX) NOT NULL,
	[PotentialRisk] [nvarchar](MAX) NOT NULL,
	[AuditorRecommendation] [nvarchar](MAX) NOT NULL,
	[Status] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [config].[IssueStatusType](Id),
	[Remarks] [nvarchar](MAX) NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0,
	)

CREATE TABLE [seven].[Action](
	[Id] [uniqueidentifier] DEFAULT NEWID() NOT NULL PRIMARY KEY,	
	[PlanId] [nvarchar](20) NOT NULL UNIQUE,
	[IssueId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Issue](Id),	
	[OwnerUserId] [BIGINT] NOT NULL FOREIGN KEY REFERENCES [security].[User](Id),
	[ManagementPlan] [nvarchar](max) NOT NULL,
	[TargetDate] [datetime] NOT NULL,
	[IsActionTaken] [bit] NOT NULL DEFAULT 0,
	[ActionTakenDate] [datetime] NULL,
	[EvidenceFilePath] [nvarchar](MAX) NULL,
	[ActionTakenRemarks] [nvarchar](MAX) NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0,
	)

CREATE TABLE [config].[IssueImpactType](
	[Id] [uniqueidentifier] DEFAULT NEWID() NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0
	)

CREATE TABLE [config].[IssueLikelihoodType](
	[Id] [uniqueidentifier] DEFAULT NEWID() NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0
	)

CREATE TABLE [config].[IssueStatusType](
	[Id] [uniqueidentifier] DEFAULT NEWID() NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0
	)

CREATE TABLE [config].[RatingType](
	[Id] [uniqueidentifier] DEFAULT NEWID() NOT NULL PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0
	)
--7.10
CREATE TABLE [seven].[IssueValidation](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[IssueId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Issue](Id),
	[ClosureSummary] [nvarchar](max) NOT NULL,
	[ValidatedByUserId] [bigint] NOT NULL FOREIGN KEY REFERENCES [security].[User](Id),
	[ValidationDate] [datetime] NOT NULL,
	[ReviewedByUserID] [bigint] NULL FOREIGN KEY REFERENCES [security].[User](Id),
	[ReviewDate] [datetime] NULL,
	[ReviewEvidenceFilePath] [nvarchar](MAX) NULL,
	[ApprovedByUserId] [bigint] NULL FOREIGN KEY REFERENCES [security].[User](Id),
	[ApprovalDate] [datetime] NULL,
	[ApprovalEvidenceFilePath] [nvarchar](MAX) NULL,
	[IssueClosureDate] [datetime] NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0,
	)