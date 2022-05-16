CREATE TABLE [eight].[AuditableFunction](
	[Id] [uniqueidentifier] PRIMARY KEY DEFAULT (NEWSEQUENTIALID()) NOT NULL ,
	[CountryId] [bigint] NOT NULL FOREIGN KEY (CountryId) REFERENCES [security].[Country](Id),  -- need to make uniqueidentifier
	[Name] nvarchar(15) NOT NULL,
	[EffeciveFrom] datetime NOT NULL,
	[EffeciveTo] datetime NOT NULL,
	[Description] nvarchar(200)  NULL,
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


CREATE TABLE [eight].[AuditableProcessCreation](
	[Id] [uniqueidentifier] PRIMARY KEY DEFAULT (NEWSEQUENTIALID()) NOT NULL ,
	[AuditableFunctionId] [uniqueidentifier] NOT NULL FOREIGN KEY (AuditableFunctionId) REFERENCES[eight].[AuditableFunction](Id),  
	[Name] nvarchar(15) NOT NULL,
	[EffeciveFrom] datetime NOT NULL,
	[EffeciveTo] datetime NOT NULL,
	[Description] nvarchar(200)  NULL,
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



CREATE TABLE [eight].[AuditableSubProcessCreation](
	[Id] [uniqueidentifier] PRIMARY KEY DEFAULT (NEWSEQUENTIALID()) NOT NULL ,
	[ProcessCreationId] [uniqueidentifier] NOT NULL FOREIGN KEY (ProcessCreationId) REFERENCES [eight].[AuditableProcessCreation](Id), 
	[Name] nvarchar(15) NOT NULL,
	[EffeciveFrom] datetime NOT NULL,
	[EffeciveTo] datetime NOT NULL,
	[Description] nvarchar(200)  NULL,
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