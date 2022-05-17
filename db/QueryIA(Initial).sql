

CREATE TABLE [security].[Designation](
	[Id] [uniqueidentifier]  PRIMARY KEY DEFAULT (NEWSEQUENTIALID()) NOT NULL ,
	[Name] [nvarchar](100) NOT NULL,
	[IsActive] bit NOT NULL DEFAULT 1,
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

CREATE TABLE [security].[Employee](
	[Id] [uniqueidentifier]  PRIMARY KEY DEFAULT (NEWSEQUENTIALID()) NOT NULL ,
	[UserId]  [bigint] NOT NULL FOREIGN KEY (UserId) REFERENCES [security].[User](Id),
	[DesignationId][uniqueidentifier] FOREIGN KEY (DesignationId) REFERENCES [security].[Designation](Id),
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Photo] [nvarchar](150) NULL,
	[IsActive] bit NOT NULL DEFAULT 1,
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


