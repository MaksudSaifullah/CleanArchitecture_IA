CREATE TABLE [nine].[RoleAssignConfigType](
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

	--Drop TABLE [nine].[RoleAssignConfigType]


CREATE TABLE [nine].[AuditRoleType](
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

	--Drop TABLE [nine].[AuditRole]





CREATE TABLE [nine].[RoleAssignConfig](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),

	[CountryId] [bigint] NOT NULL FOREIGN KEY REFERENCES [security].[Country](Id), -- [uniqueidentifier]
	[RoleId] [bigint] NOT NULL FOREIGN KEY REFERENCES [security].[Role](Id), -- [uniqueidentifier]
	[UserId] [bigint] NOT NULL FOREIGN KEY REFERENCES [security].[User](Id), -- [uniqueidentifier]
	[AuditRoleId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[AuditRole](Id),
	[RoleAssignConfigTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[RoleAssignConfigType](Id),

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

	-- Drop TABLE [nine].[RoleAssignConfig]

CREATE TABLE [nine].[Milestone](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),

	[NotificationLetterIssuance] [datetime] NOT NULL,
	[PlanningScopingStart] [datetime] NOT NULL,
	[TermsofReferenceIssuance] [datetime] NOT NULL,
	[OpeningMeeting ] [datetime] NOT NULL,
	[FieldworkStart] [datetime] NOT NULL,
	[FieldworkEnd] [datetime] NOT NULL,
	[ClosingMeeting] [datetime] NOT NULL,
	[DraftReportIssuance] [datetime] NOT NULL,
	[FinalReportIssuance] [datetime] NOT NULL,
	[RCDShareHGIA] [datetime] NOT NULL

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

	-- Drop TABLE [nine].[Milestone]