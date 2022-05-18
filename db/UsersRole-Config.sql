Use InternalAuditDb
GO

Create table [common].[Country]
(
	Id uniqueidentifier not null primary key DEFAULT (newsequentialid()),
	Name nvarchar(20) not null,
	Code nvarchar(10) not null,
	CreatedBy nvarchar(10) not null,
	CreatedOn datetime not null,
	UpdatedBy nvarchar(10) null,
	UpdatedOn datetime null,
	ReviewedBy nvarchar(10) null,
	ReviewedOn datetime null,
	ApprovedBy nvarchar(10) null,
	ApprovedOn datetime null,
	IsDeleted bit not null default(0)
)
GO

CREATE TABLE [common].[User]
(
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[UserName] nvarchar(10) not null,
	[Password] [nvarchar](100) null,
	[IsEnabled] [bit] not null default 1,
	[IsAccountExpired] [bit] not null default 0,
	[IsPasswordExpired] [bit] not null default 0,
	[IsAccountLoacked] [bit] not null default 0,
	[CreatedBy] [nvarchar](10) not null,
	[CreatedOn] [datetime] not null,
	[UpdatedBy] [nvarchar](10) null,
	[UpdatedOn] [datetime] null,
	[ReviewedBy] [nvarchar](10) null,
	[ReviewedOn] [datetime] null,
	[ApprovedBy] [nvarchar](10) null,
	[ApprovedOn] [datetime] null,
	[IsDeleted] [bit] not null default 0,
)
GO

CREATE TABLE [common].[Role]
(
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[Role] nvarchar(50) not null,
	[Description] [nvarchar](250) null,
	[IsActive] [bit] not null,
	[CreatedBy] [nvarchar](10) not null,
	[CreatedOn] [datetime] not null,
	[UpdatedBy] [nvarchar](10) null,
	[UpdatedOn] [datetime] null,
	[ReviewedBy] [nvarchar](10) null,
	[ReviewedOn] [datetime] null,
	[ApprovedBy] [nvarchar](10) null,
	[ApprovedOn] [datetime] null,
	[IsDeleted] [bit] not null default 0,
)
GO

CREATE TABLE [common].[UsersRole]
(
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[UserID] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [common].[User](Id),
	[RoleID] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [common].[Role](Id),
	[IsActive] [bit] not null default 1,
	[CreatedBy] [nvarchar](10) not null,
	[CreatedOn] [datetime] not null,
	[UpdatedBy] [nvarchar](10) null,
	[UpdatedOn] [datetime] null,
	[ReviewedBy] [nvarchar](10) null,
	[ReviewedOn] [datetime] null,
	[ApprovedBy] [nvarchar](10) null,
	[ApprovedOn] [datetime] null,
	[IsDeleted] [bit] not null default 0,
)
GO

CREATE TABLE [common].[UsersCountry]
(
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT (newsequentialid()),
	[UserID] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [common].[User](Id),
	[CountryID] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [common].[Country](Id),
	[IsActive] [bit] not null default 1,
	[CreatedBy] [nvarchar](10) not null,
	[CreatedOn] [datetime] not null,
	[UpdatedBy] [nvarchar](10) null,
	[UpdatedOn] [datetime] null,
	[ReviewedBy] [nvarchar](10) null,
	[ReviewedOn] [datetime] null,
	[ApprovedBy] [nvarchar](10) null,
	[ApprovedOn] [datetime] null,
	[IsDeleted] [bit] not null default 0,
)
GO