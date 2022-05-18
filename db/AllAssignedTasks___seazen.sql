CREATE TABLE [common].[DurationType](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](20) NOT NULL,
	[Type] [nvarchar](10) NOT NULL,   -- type will month(Jan,feb....), day(sun,mon....).... etc
	[IsActive] [bit] NOT NULL DEFAULT (1),
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
	)
	
	
CREATE TABLE [common].[Process](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	--[CountryId] [uniqueidentifier] NOT NULL FOREIGN KEY (CountryId) REFERENCES common.Country(Id), will get from auditableFuntion table
	[AuditableFunctionId] [uniqueidentifier] NOT NULL FOREIGN KEY (AuditableFunctionId) REFERENCES eight.AuditableFunction(Id),
	[Name] [nvarchar](50) NOT NULL,
	[EffeciveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
)

CREATE TABLE [common].[KeyIssuesType](
	[Id] [uniqueidentifier]  NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT (1),
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
)
	
	--IssueStatusType missing
CREATE TABLE [nine].[RiskAssessmentProcess](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[RiskAssesmentId] [uniqueidentifier] FOREIGN KEY (RiskAssesmentId) REFERENCES seven.RiskAssesment(Id),
	--[CountryId] [uniqueidentifier] FOREIGN KEY (CountryId) REFERENCES common.Country(Id),  
	--[AuditTypeId] [uniqueidentifier] FOREIGN KEY (AuditTypeId) REFERENCES common.AuditType(Id),
	[KeyIssuesTypeId] [uniqueidentifier] FOREIGN KEY (KeyIssuesTypeId) REFERENCES common.KeyIssuesType(Id),
	[IssueStatusTypeId] [uniqueidentifier] FOREIGN KEY (IssueStatusTypeId) REFERENCES eight.AuditableFunction(Id),
	--[EffectiveFrom] [nchar](10) NOT NULL,
	--[EffectiveTo] [nchar](10) NOT NULL,
	[IsExternalAuditIssue] [bit] NOT NULL,
	[IssueName] [nchar](10) NULL,
	[IsManagementConcern] [bit] NOT NULL,
	[ManagementConcern] [nvarchar](50) NULL,
	[IsRegulatoryStatutoryRequirement] [bit] NOT NULL,
	[MentionRequirement] [nvarchar](50) NULL,
	[IsWeight10FirstTimeAudit1] [bit] NOT NULL,
	[WeightedScore1] [decimal](10, 2) NULL,
	[IsWeight10KeyIssues2] [bit] NOT NULL,
	[WeightedScore2] [decimal](10, 2) NULL,
	[IsWeight10IssueStatus3] [bit] NOT NULL,
	[WeightedScore3] [decimal](10, 2) NULL,
	[IsWeight20ExternalAuditIssue4] [bit] NOT NULL,
	[WeightedScore4] [decimal](10, 2) NULL,
	[IsWeight20ManagementConcern5] [bit] NOT NULL,
	[WeightedScore5] [decimal](10, 2) NULL,
	[IsWeight30RegulatoryStatutoryRequirement6] [bit] NOT NULL,
	[WeightedScore6] [decimal](10, 2) NULL,
	[SummationOfWeights] [decimal](10, 2) NULL,
	[RiskRating] [nvarchar](50) NOT NULL,
	[AuditFrequency] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT(0)
 )
 
 CREATE TABLE [seven].[AuditPlan](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[CountryId] [uniqueidentifier] NOT NULL FOREIGN KEY ([CountryId]) REFERENCES common.Country(Id),
	[AuditTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY ([CountryId]) REFERENCES common.AuditType(Id),
	[AuditPlanCode] [uniqueidentifier] NOT NULL,
	[PlanningYear] [int] NOT NULL,
	[RiskAssesmentId] [uniqueidentifier] NOT NULL,
	[EffectiveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,	
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL,
 )
 
 
CREATE TABLE [nine].[AuditSubPlan](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[AuditPlanId] [uniqueidentifier] NOT NULL FOREIGN KEY (AuditPlanId) REFERENCES seven.AuditPlan(Id),
	[DurationTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY (DurationTypeId) REFERENCES common.DurationType(Id),
	[ReviewPeriodFrom] [datetime] NOT NULL,
	[ReviewPeriodTo] [datetime] NOT NULL,
	[AvailableManDays] [int] NOT NULL,
	[RequiredManDays] [int] NOT NULL,
	[SurplusDeficit] [int] NOT NULL,
	[Rationale] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
) 



CREATE TABLE [nine].[AuditSubPlanProcess](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[AuditSubPlanId] [uniqueidentifier] NOT NULL FOREIGN KEY (AuditSubPlanId) REFERENCES nine.AuditSubPlan(Id),
	[AuditableFunctionId] [uniqueidentifier] NOT NULL FOREIGN KEY (AuditableFunctionId) REFERENCES eight.AuditableFunction(Id),
	[ProcessId] [uniqueidentifier] NOT NULL FOREIGN KEY (ProcessId) REFERENCES common.Process(Id),
	[RatingTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY (RatingTypeId) REFERENCES config.RatingType(Id),
	[IsChecked] [bit] NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
 )
 
 
 
 
 
 
 CREATE TABLE [common].[AuditFrequencyType](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](20) NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
)
 
 CREATE TABLE [common].[AuditType](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
)
 
 CREATE TABLE [common].[Score](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Score] [nvarchar](20) NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
	)
	
	
	CREATE TABLE [six].[AuditFrequency](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[CountryId] [uniqueidentifier] NOT NULL FOREIGN KEY (CountryId) REFERENCES common.Country(Id),
	[ScoreId] [uniqueidentifier] NOT NULL FOREIGN KEY (ScoreId) REFERENCES common.Score(Id),
	[RatingTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY (RatingTypeId) REFERENCES config.RatingType(Id),
	[AuditFrequencyTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY (AuditFrequencyTypeId) REFERENCES common.AuditFrequencyType(Id),
	[EffeciveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
)


CREATE TABLE [seven].[RiskAssesment](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[CountryId] [uniqueidentifier] NOT NULL FOREIGN KEY (CountryId) REFERENCES common.Country(Id),
	[AuditTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY (AuditTypeId) REFERENCES common.AuditType(Id),
	[AssesmentCode] [nvarchar](50) NOT NULL,
	[EffectiveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT (0)
	)
	
	
	
	
	
	
	