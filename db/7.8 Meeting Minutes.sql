Use InternalAuditDb
GO

Create table [dbo].[MeetingMinutesBase]
(
	Id uniqueidentifier not null primary key,
	ScheduleId uniqueidentifier not null, --foreign key references [dbo].[Schedule](Id)
	BranchId uniqueidentifier not null, --foreign key references [dbo].[Branch](Id)
	PreparedBy uniqueidentifier not null,-- foreign key references [security].[Employee](Id),
	AgreedBy uniqueidentifier null,-- foreign key references [security].[Employee](Id),
	MeetingCode nvarchar(20) not null unique,		
	HeldOn datetime not null, --?? what does it stand for?
	[Name] nvarchar(100) not null,
	AuditOn nvarchar(100) not null, --?? what does it stand for?
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
Go

Create table [dbo].[MeetingMinutesAttendee]
(
	Id uniqueidentifier not null primary key,
	MeetingMinutesBaseId uniqueidentifier not null, --foreign key references [dbo].[MeetingMinutesBase](Id)
	AttendeeId uniqueidentifier, -- foreign key references [security].[Employee](Id),
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

Create table [dbo].[MeetingMinutesAppology]
(
	Id uniqueidentifier not null primary key,
	MeetingMinutesBaseId uniqueidentifier not null, --foreign key references [dbo].[MeetingMinutesBase](Id)
	AppologyById uniqueidentifier, -- foreign key references [security].[Employee](Id),
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

Create table [dbo].[MeetingMinutes]
(
	Id uniqueidentifier not null primary key,
	MeetingMinutesBaseId uniqueidentifier not null, --foreign key references [dbo].[MeetingMinutesBase](Id)
	SubjectOwnerId uniqueidentifier, -- foreign key references [security].[Employee](Id),
	SubjectMatter nvarchar(300) not null,
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