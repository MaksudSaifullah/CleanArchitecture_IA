CREATE TABLE [six].[TopicHead](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[IsActive] [bit] NOT NULL DEFAULT 1,
	[Name] [nvarchar](100) NOT NULL,
	[EffectiveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CountryId] [bigint] NOT NULL FOREIGN KEY REFERENCES [security].[Country](Id),
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

	-- Drop TABLE [six].[TopicHead]

CREATE TABLE [six].[WeightScore](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[WeightScore] DECIMAL(5,2) NOT NULL,
	[EffectiveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,
	[Description] [nvarchar](500) NULL,

	[CountryId] [bigint] NOT NULL FOREIGN KEY REFERENCES [security].[Country](Id),
	[TopicHeadId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [six].[TopicHead](Id),

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

	-- Drop TABLE [six].[WeightScore]

CREATE TABLE [six].[RiskCriteria](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[Name] [nvarchar](100) NOT NULL,
	[Weight] DECIMAL(5,2) NOT NULL,
	[EffectiveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,
	
	[MinimumValue] DECIMAL(5,2) NOT NULL,
	[MaximumValue] DECIMAL(5,2) NOT NULL,
	[Score] DECIMAL(5,2) NOT NULL,
	[Description] [nvarchar](500) NULL,

	[CountryId] [bigint] NOT NULL FOREIGN KEY REFERENCES [security].[Country](Id),
	[RatingTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[RatingType](Id),
	[RiskCriteriaTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [six].[RiskCriteriaType](Id),
	[AuditTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [common].[AuditType](Id),

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

	-- Drop TABLE [six].[RiskCriteria]

CREATE TABLE [six].[RiskCriteriaType](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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

	--Drop TABLE [six].[RiskCriteriaTab]


CREATE TABLE [six].[TestSteps](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),	
	[CountryId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [common].[Country](Id),
	[TopicHeadId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [six].[TopicHead](Id),
	[QuestionaireId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [six].[Questionaire](Id),
	[Title] [nvarchar](500) NOT NULL,
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
	[IsDeleted] [bit] NOT NULL DEFAULT 0,
	)

	--Drop TABLE [six].[TestSteps]