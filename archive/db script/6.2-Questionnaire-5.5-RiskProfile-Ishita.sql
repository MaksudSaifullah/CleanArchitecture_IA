CREATE TABLE [six].[Questionnaire](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[CountryId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [common].[Country](Id),
	[TopicHeadId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [six].[TopicHead](Id),
	[Question] [nvarchar](500) NOT NULL,
	[EffectiveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,
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

CREATE TABLE [five].[RiskProfile](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[LikelihoodTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[LikelihoodType](Id), --will there be any generic table?
	[ImpactTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[ImpactType](Id), --will there be any generic table?
	[RatingType] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[RatingType](Id),	
	[EffectiveFrom] [datetime] NOT NULL,
	[EffectiveTo] [datetime] NOT NULL,
	[Description] [nvarchar](200) NULL,
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