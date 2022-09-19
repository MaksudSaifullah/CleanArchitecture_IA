
--  delte hye jbae eight theke AuditableFunction table
-- nine (audit subplan need to use common function)
CREATE TABLE [common].[Function](
	[Id] [uniqueidentifier] PRIMARY KEY DEFAULT (NEWSEQUENTIALID()) NOT NULL ,
	[CountryId] [uniqueidentifier] NOT NULL FOREIGN KEY (CountryId) REFERENCES [common].[Country](Id),  -- need to make uniqueidentifier
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


-- table name needs to rename
CREATE TABLE [common].[SubProcess](
	[Id] [uniqueidentifier] PRIMARY KEY DEFAULT (NEWSEQUENTIALID()) NOT NULL ,
	[ProcessId] [uniqueidentifier] NOT NULL FOREIGN KEY (ProcessId) REFERENCES [common].[Process](Id), 
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