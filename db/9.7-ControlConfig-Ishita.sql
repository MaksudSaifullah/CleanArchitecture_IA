CREATE TABLE [config].[Entity](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Code] [nvarchar](20) NOT NULL, --if needed
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

CREATE TABLE [nine].[ControlConfiguration](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[AuditId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[AuditCreation](Id),
	[AuditableEntityId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[Entity](Id),
	[ProcessId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[Process](Id), --table from emran vai
	[RiskNameId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[RiskName](Id),
	[ControlName] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[ControlName](Id),
	[ControlCode] [nvarchar](50) NULL,
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
	[IsDeleted] [bit] NOT NULL DEFAULT 0
)
