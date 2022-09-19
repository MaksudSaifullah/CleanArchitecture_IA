--Opening Meeting Minutes
--Line of Business - > All auditable entities tagged in that audit
--need to modify Meeting Minutes Table from epic seven

CREATE TABLE [common].[LineOfBusiness] (
[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[Name] [nvarchar](50) NOT NULL,

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

-- OE Test Script
CREATE TABLE [nine].[OETestScript](
[Id] [uniqueidentifier] NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
[OETestCode] [nvarchar](20) NOT NULL UNIQUE,

[RCE-DEId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [nine].[RCDDesignPhase](Id), --
[SampleName] [nvarchar](200) NOT NULL,
[DateofTesting] [datetime] NOT NULL,

[SampleMonthId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES  [common].[DurationType](Id) ,

[AuditPeriodFrom] [datetime] NOT NULL,
[AuditPeriodTo] [datetime] NOT NULL,

[ControlActivityNatureId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[ControlActivityNature](Id),
[ControlFrequencyId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[ControlFrequency](Id),
[SampleSize] [int] NOT NULL,
[SampleSelectionMethodId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [config].[SampleSelectionMethodType](Id), -- from 7.7

[OETestSteps] [nvarchar](200) NOT NULL,
[OETestResult] [nvarchar](200) NOT NULL,
[OETestConclusion] [nvarchar](5) NOT NULL,
[IsIssueIdentified] [bit] NOT NULL,
[IsIssueReportable] [bit] NOT NULL,
[IssueDetails] [nvarchar](200) NOT NULL,
[IssueEvidenceReference] [nvarchar](200) NOT NULL,

[DocumentId] [uniqueidentifier] NOT NULL FOREIGN KEY REFERENCES [dms].[Document](Id),
[Remarks] [nvarchar](200) NOT NULL,


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




