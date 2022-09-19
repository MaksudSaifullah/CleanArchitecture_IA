--7.10
CREATE TABLE [seven].[IssueValidation](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[IssueId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Issue](Id),
	[ValidatedByUserId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ReviewedByUserID] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ApprovedByUserId] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ReviewEvidenceDocumentId] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [dms].[Document](Id),
	[ApprovalEvidenceDocumentId] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [dms].[Document](Id),
	[ClosureSummary] [nvarchar](500) NOT NULL,	
	[ValidationDate] [datetime] NOT NULL,	
	[ReviewDate] [datetime] NULL,	
	[ApprovalDate] [datetime] NULL,	
	[IssueClosureDate] [datetime] NULL,
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

CREATE TABLE [seven].[IssueValidationAction](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[IssueValidationActionCode] [nvarchar](20) NOT NULL UNIQUE,
	[ActionOwner] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[OETestControlActivityNatureId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[ControlActivityNature](Id),
	[OETestControlFrequencyId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[ControlFrequency](Id),
	[ActionValidatedBy] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ActionReviewedBy] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ActionApprovedBy] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[Name] [nvarchar](50) NOT NULL,
	[Details] [nvarchar](50) NOT NULL,
	[ManagementPlan] [nvarchar](200) NOT NULL,	
	[ActionTargetDate] [Datetime] NOT NULL,
	[DEATestConclusion] [nvarchar](300) NOT NULL,
	[OETestDetails] [nvarchar](500) NOT NULL,	
	[SampleSize] [int] NOT NULL,
	[OETestConclusion] [nvarchar](300) NOT NULL,	
	[ActionValidationDate] [datetime] NOT NULL,	
	[ActionReviewDate] [datetime] NULL,	
	[ActionApprovedDate] [datetime] NULL,
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

CREATE TABLE [config].[DETestQuestion](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Question] [nvarchar](10) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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

CREATE TABLE [seven].[IssueValidationActionDETestQuestionsAnswer](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[IssueValidationActionId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[IssueValidationAction](Id),
	[DETestQuestionId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[DETestQuestion](Id),
	[Answer] [int] NOT NULL,
	[Remarks] [nvarchar](200) NULL,
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

CREATE TABLE [config].[ControlActivityNature](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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
-- no need, will use durationtype table
CREATE TABLE [config].[ControlFrequency](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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

CREATE TABLE [seven].[IssueValidationActionDocumentType](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
	[CreatedBy] [nvarchar](10) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](10) NULL,
	[UpdatedOn] [datetime] NULL,
	[ReviewedBy] [nvarchar](10) NULL,
	[ReviewedOn] [datetime] NULL,
	[ApprovedBy] [nvarchar](10) NULL,
	[ApprovedOn] [datetime] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0
) --testing sheets, evidence details, DE test testing sheets, DE test evidence, OE test testing sheets, OE test evidence, review evidence, approval evidence, closure report

CREATE TABLE [seven].[IssueValidationActionDocuments](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[IssueValidationActionId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[IssueValidationAction](Id),
	[IssueValidationActionDocumentTypeId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[IssueValidationActionDocumentType](Id),
	[DocumentId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [dms].[Document](Id),
	--[Name] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL DEFAULT 1,
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
-- 7.11
CREATE TABLE [seven].[AuditExecutionReport](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[ReportCode] [nvarchar](20) NOT NULL UNIQUE,	
	[AuditId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Audit](Id),
	[Country] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [common].[Country](Id),
	[ReportIssuedBy] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ReportReviewedBy] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ReportApprovedBy] [uniqueidentifier] NULL FOREIGN KEY REFERENCES [security].[Employee](Id),
	[ReviewEvidenceId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [dms].[Document](Id),
	[ApprovalEvidenceId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [dms].[Document](Id),
	[ReportIssueDate] [datetime] NOT NULL,	
	[Environment] [nvarchar](500) NOT NULL,
	[ScopeOfReview] [nvarchar](500) NOT NULL,
	[Opinion] [nvarchar](500) NOT NULL,
	[ReportReviewDate] [datetime] NULL,
	[ReportApproveDate] [datetime] NULL,
	[DraftVersion] [int] NOT NULL,
	[IsFinal] [bit] NOT NULL DEFAULT 0, --draft or final
	[IsActive] [bit] NOT NULL DEFAULT 1,
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
CREATE TABLE [seven].[AuditExecutionReportIssues](
	[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[AuditExecutionReportId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[AuditExecutionReport](Id),
	[IssueId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [seven].[Issue](Id),
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