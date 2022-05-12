--7.9
CREATE TABLE [seven].[Issue](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
	[IssueCode] [nvarchar](20) NOT NULL UNIQUE,
	[IssueTitle] [nvarchar](100) NOT NULL,
	[AuditId] [uniqueidentifier] NOT NULL, --FK of Audit
	[AuditScheduleId] [uniqueidentifier] NOT NULL, --FK for Schedule
	[BranchId] [uniqueidentifier] NOT NULL, --FK for Branch
	[IssueOwnerId] [BIGINT] NOT NULL FOREIGN KEY REFERENCES [security].[User](Id),--todo
	[Policy] [nvarchar](500) NOT NULL,
	[ImpactTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [Config].[IssueImpactType](Id),
	[LikelihoodTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[IssueLikelihoodType](Id),
	[RatingTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[RatingType](Id),
	[TargetDate] [datetime] NOT NULL,
	[Details] [nvarchar](500) NOT NULL,
	[RootCause] [nvarchar](500) NOT NULL,
	[BusinessImpact] [nvarchar](500) NOT NULL,
	[PotentialRisk] [nvarchar](500) NOT NULL,
	[AuditorRecommendation] [nvarchar](500) NOT NULL,
	[Status] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [config].[IssueStatusType](Id),
	[Remarks] [nvarchar](500) NULL, ---- status hisotry table
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
	[PlanCode] [nvarchar](20) NOT NULL UNIQUE,
	[IssueId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Issue](Id),	
	[OwnerUserId] [BIGINT] NOT NULL FOREIGN KEY REFERENCES [security].[User](Id),
	[ManagementPlan] [nvarchar](500) NOT NULL,
	[TargetDate] [datetime] NOT NULL,
	[IsActionTaken] [bit] NOT NULL DEFAULT 0,
	[ActionTakenDate] [datetime] NULL,
	[EvidenceFilePath] [nvarchar](MAX) NULL,-- ref with document table 
	[ActionTakenRemarks] [nvarchar](500) NULL,
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
	--IsActive
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
	--IsActive
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
	--IsActive
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
	--IsActive
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
	[ReviewEvidenceFilePath] [nvarchar](MAX) NULL,-- ref with document table 
	[ApprovedByUserId] [bigint] NULL FOREIGN KEY REFERENCES [security].[User](Id),--[uniqueidentifier]
	[ApprovalDate] [datetime] NULL,
	[ApprovalEvidenceFilePath] [nvarchar](MAX) NULL,-- ref with document table 
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

	-- IssueValidationAction table