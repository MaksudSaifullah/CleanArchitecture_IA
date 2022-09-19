Use InternalAuditDb
GO

Create table [config].[TestConclusionType]
(
	Id uniqueidentifier not null,
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

Create table [config].[DocumentSource]
(
	Id uniqueidentifier not null,
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

Create table [dbo].[BranchChecklistOverview]
(
	Id uniqueidentifier not null primary key,
	ChecklistCode nvarchar(20) not null unique,
	ScheduleId uniqueidentifier not null, --foreign key references [dbo].[Schedule](Id)
	BranchId uniqueidentifier not null, --foreign key references [dbo].[Branch](Id)
	RegionId uniqueidentifier not null, --foreign key references [dbo].[Region](Id)
	DateOfOpening datetime not null,
	FirstLoanDisbursementDate datetime not null,
	BranchManager nvarchar(50) not null,
	BranchManagerJoiningDate datetime not null,
	DateOfAudit datetime not null,
	PeriodFrom datetime not null,
	PeriodTo datetime not null,
	LastPeriodFrom datetime null,
	LastPeriodTo datetime null,
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

Create table [dbo].[BranchChecklistTestStep]
(
	Id uniqueidentifier not null primary key,
	TopicsHeadId uniqueidentifier not null, --references [dbo].[TopicsHead](Id)
	Result nvarchar(100) not null,
	TestConclusionTypeId uniqueidentifier not null references [config].[TestConclusionType](Id),
	Score decimal(10,5) not null,
	ObtainedScore decimal(10,5) not null,
	[Weight] decimal(10,5) not null,
	WeightedScore decimal(10,5) not null,
	--DocumentId uniqueidentifier null foreign key references [dms].[Document](Id),
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

Create table [dbo].[BranchChecklistTestStepEvidenceDocument]
(
	Id uniqueidentifier not null primary key,
	BranchChecklistTestStepId uniqueidentifier not null foreign key references [dbo].[BranchChecklistTestStep](Id),
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

Create table [dms].[Document]
(
	Id uniqueidentifier not null primary key,
	DocumentSourceId uniqueidentifier not null foreign key references [config].[DocumentSource](Id),
	[Path] nvarchar(200) not null,
	[Name] nvarchar(50) not null,
	[Format] nvarchar(10) not null,
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