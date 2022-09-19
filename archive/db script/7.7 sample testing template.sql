Use InternalAuditDb
GO

Create table [config].[ControlActivityType]
(
	Id uniqueidentifier not null primary key,
	[Name] nvarchar(50) not null,
	IsActive bit not null default(1),
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
Go

Create table [config].[SampleSelectionMethodType]
(
	Id uniqueidentifier not null primary key,
	[Name] nvarchar(50) not null,
	IsActive bit not null default(1),
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
Go

Create table [dbo].[SampleTestingTemplate]
(
	Id uniqueidentifier not null primary key,
	WorkpaperCode nvarchar(20) not null unique,
	ScheduleId uniqueidentifier not null, --foreign key references [dbo].[Schedule](Id)
	TopicHeadId uniqueidentifier not null, --foreign key references [dbo].[TopicHead](Id)
	BranchId uniqueidentifier not null, --foreign key references [dbo].[Branch](Id)
	QuestionnaireId uniqueidentifier not null, --foreign key references [dbo].[Questionaaire](Id)
	Particulars nvarchar(100) not null,
	DateOfTesting datetime not null,
	SampledMonth int not null,
	ControlActivitynTypeId uniqueidentifier not null foreign key references [config].[ControlActivitynType](Id),
	SampleSize int not null, --??
	SampleSelectionMethodTypeId uniqueidentifier not null foreign key references [config].[SampleSelectionMethodType](Id),
	PeriodFrom datetime not null,
	PeriodTo datetime not null,
	Details nvarchar(500) null,
	Result nvarchar(500) null,
	TestConclusionTypeId uniqueidentifier not null foreign key references [config].[TestConclusionType](Id),
	[Status] int not null, -- 0 = draft, 1 = saved etc.
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

Create table [dbo].[SampleTestingTemplateEvidenceDocument]
(
	Id uniqueidentifier not null primary key,
	SampleTestingTemplateId uniqueidentifier not null foreign key references [dbo].[BranchChecklistTestStep](Id),
	DocumentId uniqueidentifier null foreign key references [dms].[Document](Id),
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