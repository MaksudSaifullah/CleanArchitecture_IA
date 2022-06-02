--CREATE TABLE [five].[UploadDocument](
--	[Id] [uniqueidentifier] PRIMARY KEY DEFAULT (newid()) NOT NULL,
--	[Name] [nvarchar](100) NOT NULL,
--	[Version] [nvarchar](3) NOT NULL,
--	[Description]  [nvarchar](200) NULL,
--	[Status] [bit] NOT NULL,
--	[StartingDate] [datetime] NOT NULL,
--	[EndingDate] [datetime] NOT NULL,
--	[FilePath]  [nvarchar](200) NOT NULL,	
--	[CreatedBy] [nvarchar](10) NOT NULL,
--	[UpdatedBy] [nvarchar](10) NULL,
--	[CreatedOn] [datetime] NULL,
--	[UpdatedOn] [datetime] NULL,
--	[IsDelete] [bit] NULL  DEFAULT ((0)) ,	
--	[ApprovedBy] [nvarchar](10) NULL,
--	[ApprovedOn] [datetime] NULL,
--	[ReviewedBy] [nvarchar](10) NULL,
--	[ReviewedOn] [datetime] NULL

--)
CREATE TABLE [five].[UploadDocumentNotifyList](
	[Id] [uniqueidentifier] PRIMARY KEY  DEFAULT (newid()) NOT NULL ,
	[DocumentId] [uniqueidentifier] NOT NULL CONSTRAINT FK_UploadDocumentNotify FOREIGN KEY (DocumentId) REFERENCES [five].[UploadDocument](Id),
	[RoleId] [bigint] NOT NULL CONSTRAINT FK_RoleDocumentNotify FOREIGN KEY (RoleId) REFERENCES [security].[Role](ID), -- change with uniqueidentifier
	[IsEmailSent][bit] NULL  DEFAULT ((0)) ,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDelete] [bit] NULL  DEFAULT ((0)) ,	
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL

)


CREATE TABLE [five].[DashBoardBaseConfig](
	[Id] [uniqueidentifier] PRIMARY KEY  DEFAULT (newid()) NOT NULL ,
	[Name] [nvarchar](30) NOT NULL,	
	[Status][bit] NULL  DEFAULT ((1)) ,	
	[CreatedBy] [nvarchar](10) NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDelete] [bit] NULL  DEFAULT ((0)) ,	
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL

)

CREATE TABLE [five].[DashBoardBaseConfigurationUserWise](
	[Id] [uniqueidentifier] PRIMARY KEY  DEFAULT (newid()) NOT NULL ,
	[DashBoardBaseConfigId] [uniqueidentifier] NOT NULL CONSTRAINT FK_DashBoardBaseConfigUserMap FOREIGN KEY (DashBoardBaseConfigId) REFERENCES [five].[DashBoardBaseConfig](Id),
	[UserId] [uniqueidentifier] NOT NULL ,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDelete] [bit] NULL  DEFAULT ((0)) ,	
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL

)

CREATE TABLE [five].[EmailTypeConfig](
	[Id] [uniqueidentifier] PRIMARY KEY  DEFAULT (newid()) NOT NULL ,	
	[Name] [nvarchar](30) NOT NULL,		
	[Status][bit] NULL  DEFAULT ((1)) ,	
	[CreatedBy] [nvarchar](10) NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDelete] [bit] NULL  DEFAULT ((0)) ,	
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL

)


CREATE TABLE [five].[EmailBaseConfig](
	[Id] [uniqueidentifier] PRIMARY KEY  DEFAULT (newid()) NOT NULL ,
	[CountryId] [bigint]   NOT NULL  CONSTRAINT FK_EmailBaseConfigEmailTypeMap FOREIGN KEY (CountryId) REFERENCES [security].[Country](Id), -- change with uniqueidentifier
	[EmailTypeId] [uniqueidentifier] NOT NULL CONSTRAINT FK_EmailBaseTypeConfig FOREIGN KEY (EmailTypeId) REFERENCES [five].[EmailTypeConfig](Id),	
	[SubjectTemplate] [nvarchar](200) NOT NULL,	
	[BodyTemplate] [nvarchar](max) NOT NULL,	
	[Status][bit] NULL  DEFAULT ((1)) ,	
	[CreatedBy] [nvarchar](10) NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[IsDelete] [bit] NULL  DEFAULT ((0)) ,	
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL

)


