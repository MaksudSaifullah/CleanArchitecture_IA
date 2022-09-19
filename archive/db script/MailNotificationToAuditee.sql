

CREATE TABLE [seven].[MailNotificationToAuditee]   -- may be used by 9.9(epic)
(
	[Id] [uniqueidentifier] NOT NULL primary key default newsequentialid(),
	[AuditId] [uniqueidentifier] NOT NULL foreign key references [seven].[Audit](Id),
	[RiskOwerTo] [nvarchar](max) NOT NULL,
	[OthersTo] [nvarchar](max) NULL,
	[Cc] [nvarchar](max) NULL,
	[OthersCc] [nvarchar](max) NULL,
	[Bcc] [nvarchar](max) NULL,
	[OthersBcc] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL default(0)
)
