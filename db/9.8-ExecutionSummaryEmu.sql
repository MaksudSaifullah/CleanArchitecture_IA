CREATE TABLE [nine].[ExecutionSummary](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),

	[AuditId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[ProcessAndControlAuditCreation](Id),
	[SubplanId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[AuditSubplan](Id),
	
	--Team Leader Process & Control Audit - > Configuration - > Assign Auditor
	-- Auditor Process & Control Audit - > Configuration - > Assign Auditor
	-- Planning & Scoping
	-- Field Work 

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