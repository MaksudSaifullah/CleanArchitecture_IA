Use InternalAuditDb
GO

Create table [security].[PasswordPolicy]
(
	Id uniqueidentifier not null primary key,
	MinLength int not null,
	[MaxLength] int not null,
	AllowAlphabet bit not null,
	AlphabetLength int null,
	AllowNumeric bit not null,
	NumericLength int null,
	AllowSpecialChars bit not null,
	SpecialCharsLength int null,
	ChangePasswordOnFirstLogin bit not null,
	ForcePasswordReset bit not null,
	ForcePasswordResetDays int null,
	NotifyPasswordResetDays int null,
	StartDate datetime not null,
	EndDate datetime null,
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

Create table [security].[UserLockingPolicy]
(
	Id uniqueidentifier not null primary key,
	LockedOnNoLoginActivity bit not null,
	NoLoginActivityDays int null,
	LockedOnFailedLoginAttempts bit not null,
	NumberOfFailedLoginAttempts int null,
	FailedLoginAttemptsDuration int null,
	FailedLoginLockedDuration int null,
	UnlockedOnByAdmin bit not null,
	UnlockedOnByAdminDuration int null,
	StartDate datetime not null,
	EndDate datetime null,
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

Create table [security].[SessionPolicy]
(
	Id uniqueidentifier not null primary key,
	IsEnabled bit not null,
	Duration int null,
	StartDate datetime not null,
	EndDate datetime null,
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