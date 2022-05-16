Use InternalAuditDb
GO

Create table [dbo].[RiskConfiguration]
(
	Id uniqueidentifier not null primary key,
	AuditId uniqueidentifier not null, --foreign key references [dbo].[Audit](Id)
	EntityId uniqueidentifier not null, --foreign key references [dbo].[Entity](Id)
	ProcessId uniqueidentifier not null, --foreign key references [dbo].[Process](Id) ?? is process table already exits?
	ProcessCode nvarchar(20) not null,
	[Name] nvarchar(100) not null,
	[Description] nvarchar(500) not null,
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