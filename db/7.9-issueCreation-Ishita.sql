CREATE TABLE [seven].[Issue](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[IssueCode] [nvarchar](20) NOT NULL UNIQUE,
	[AuditId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Audit](Id),
	[AuditScheduleId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[AuditSchedule](Id),
	[BranchId] [uniqueidentifier] NOT NULL, --FK for Branch	
	[ImpactTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [Config].[IssueImpactType](Id),
	[LikelihoodTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[IssueLikelihoodType](Id),
	[RatingTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[RatingType](Id),
	[StatusTypeId] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [config].[IssueStatusType](Id),
	[IssueTitle] [nvarchar](100) NOT NULL,	
	[Policy] [nvarchar](500) NOT NULL,	
	[TargetDate] [datetime] NOT NULL,
	[Details] [nvarchar](500) NOT NULL,
	[RootCause] [nvarchar](500) NOT NULL,
	[BusinessImpact] [nvarchar](500) NOT NULL,
	[PotentialRisk] [nvarchar](500) NOT NULL,
	[AuditorRecommendation] [nvarchar](500) NOT NULL,
	[Remarks] [nvarchar](500) NULL,
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

CREATE TABLE [seven].[IssueAction](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[PlanCode] [nvarchar](20) NOT NULL UNIQUE,
	[IssueId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Issue](Id),	
	[OwnerId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[EvidenceDocumentId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [dms].[Document](Id),
	[ManagementPlan] [nvarchar](500) NOT NULL,
	[TargetDate] [datetime] NOT NULL,
	[IsActionTaken] [bit] NOT NULL DEFAULT 0,
	[ActionTakenDate] [datetime] NULL,	
	[ActionTakenRemarks] [nvarchar](500) NULL,
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

CREATE TABLE [seven].[IssueOwners](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[IssueId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Issue](Id),	
	[OwnerId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[IsActive] [bit] NOT NULL DEFAULT 1,
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

CREATE TABLE [seven].[IssueStatusHistory](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[IssueId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Issue](Id),
	[IssueStatusId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[IssueStatusType](Id),
	[ModifiedBy] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ModificationDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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

CREATE TABLE [config].[IssueImpactType](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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