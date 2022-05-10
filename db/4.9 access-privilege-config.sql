Use InternalAuditDb
GO

Create table [security].[PasswordPolicy]
(
	Id bigint not null primary key identity(1,1),
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
	UpdatedOn datetime null
)
GO

Create table [security].[UserLockingPolicy]
(
	Id bigint not null primary key identity(1,1),
	LockedOnNoLoginActivity bit not null,
	NoLoginActivityDays int null,
	LockedOnFailedLoginAttempts bit not null,
	NumberOfFailedLoginAttempts int null,
	FailedLoginAttemptsDuration int null,
	FailedLoginLockedDuration int null,
	StartDate datetime not null,
	EndDate datetime null,
	CreatedBy nvarchar(10) not null,
	CreatedOn datetime not null,
	UpdatedBy nvarchar(10) null,
	UpdatedOn datetime null
)
GO