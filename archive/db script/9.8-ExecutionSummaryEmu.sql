-- Not neccessary as it will only auto-load data 
--CREATE TABLE [nine].[ExecutionSummary](
--	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),

--	[AuditId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[ProcessAndControlAuditCreation](Id),
--	[SubplanId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[AuditSubplan](Id),
	
--	[AuditRoleId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[AuditRoleType](Id),

--	[CreatedBy] [nvarchar](10) NOT NULL,
--	[CreatedOn] [datetime] NOT NULL,
--	[UpdatedBy] [nvarchar](10) NULL,
--	[UpdatedOn] [datetime] NULL,
--	[ReviewedBy] [nvarchar](10) NULL,
--	[ReviewedOn] [datetime] NULL,
--	[ApprovedBy] [nvarchar](10) NULL,
--	[ApprovedOn] [datetime] NULL,
--	[IsDeleted] [bit] NOT NULL DEFAULT 0,
--	)


	--9.9 already created by Sumon bhai in seven epic

	CREATE TABLE [nine].[NotificationToAuditee](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[AuditId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[ProcessAndControlAuditCreation](Id),

	[AuditeeTo] [nvarchar](max) NOT NULL, -- name different from epic seven
	[OthersTo] [nvarchar](max) NULL,
	[Cc] [nvarchar](max) NULL,
	[OthersCc] [nvarchar](max) NULL,
	[Bcc] [nvarchar](max) NULL,
	[OthersBcc] [nvarchar](max) NULL,

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