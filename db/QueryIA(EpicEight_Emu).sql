CREATE TABLE [eight].[AuditFrequency](
[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (NEWID()),
[CountryId] [bigint] NOT NULL CONSTRAINT FK_AuditFrequencyMap FOREIGN KEY (CountryId) REFERENCES [security].[Country](Id),  -- change with uniqueidentifier
[RiskRatingTypeId] [uniqueidentifier] NOT NULL CONSTRAINT FK_AuditFrequencyRiskType FOREIGN KEY(RiskRatingTypeId) REFERENCES [common].[RiskRatingType](Id), 
[AuditFrequencyTypeId] [uniqueidentifier] NOT NULL CONSTRAINT FK_AuditFrequencyAuditFrequency FOREIGN KEY(AuditFrequencyTypeId) REFERENCES [common].[AuditFrequencyType](Id),
[StartingDate] [datetime] NOT NULL,
[EndingDate] [datetime] NOT NULL,
[CreatedBy] [nvarchar](10) NOT NULL,
[UpdatedBy] [nvarchar](10) NULL,
[CreatedOn] [datetime] NULL,
[UpdatedOn] [datetime] NULL,
[IsDelete] [bit] NULL DEFAULT ((0)) ,
[ApprovedBy] [nvarchar](10) NULL,
[ApprovedOn] [datetime] NULL,
[ReviewedBy] [nvarchar](10) NULL,
[ReviewedOn] [datetime] NULL


)

CREATE TABLE [eight].[RiskRating](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (NEWID()),
	[CountryId] [bigint] NOT NULL CONSTRAINT FK_RiskRatingMap FOREIGN KEY (CountryId) REFERENCES [security].[Country](Id),  -- change with uniqueidentifier
	[RiskRatingTypeId] [uniqueidentifier] NOT NULL CONSTRAINT FK_RiskRatingType FOREIGN KEY(RiskRatingTypeId) REFERENCES [common].[RiskRatingType](Id), 
	[MinWeightSum] [int]  NOT NULL,
	[MaxWeightSum] [int]  NOT NULL,
	[StartingDate] [datetime] NOT NULL,
	[EndingDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDelete] [bit] NULL DEFAULT ((0)) ,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL
)

CREATE TABLE [eight].[RiskCriteria](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (NEWID()),
	[CountryId] [bigint] NOT NULL CONSTRAINT FK_RiskCriteriaMap FOREIGN KEY (CountryId) REFERENCES [security].[Country](Id),  -- change with uniqueidentifier
	[Name] [nvarchar](max) NOT NULL,
	[Weight] [int] NOT NULL,
	[StartingDate] [datetime] NOT NULL,
	[EndingDate] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDelete] [bit] NULL DEFAULT ((0)) ,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL


)
