using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetAuditScheduleListProcedureUpdateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"Create OR ALTER PROCEDURE [dbo].[GetAuditScheduleListProcedure]
@pageSize int,
@pageNumber int,
@searchTerm nvarchar(50)
AS
BEGIN


SELECT a.Id, c.Name Country,a.ScheduleId,a.ScheduleState,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.UserId=u.Id and x.CommonValueParticipantId=1
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) Approver,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.UserId=u.Id and x.CommonValueParticipantId=2
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) TeamLeader,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.UserId=u.Id and x.CommonValueParticipantId=3
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) Auditor
,a.ScheduleStartDate,a.ScheduleEndDate, 
'' as ExecutionStatus,'' as ScheduleStatus,
a.CreatedOn
FROM [BranchAudit].AuditSchedule a
INNER JOIN [BranchAudit].[AuditCreation] ac on a.AuditCreationId=ac.Id
INNER JOIN [BranchAudit].[AuditPlan] ap on ac.AuditPlanId=ap.Id
INNER JOIN [BranchAudit].[RiskAssessment] ra on ap.RiskAssessmentId=ra.Id
INNER JOIN [common].[Country] c on ra.CountryId=c.Id
INNER JOIN [BranchAudit].[AuditScheduleParticipants] asp on a.Id=asp.AuditScheduleId
INNER JOIN [security].[User] u on asp.UserId=u.Id

WHERE a.IsDeleted=0 AND ((@searchTerm is null or @searchTerm = '') or a.Id like '%'+@searchTerm+'%')
GROUP BY a.Id,u.Id,c.Name,u.UserName,a.ScheduleEndDate,a.ScheduleStartDate,a.CreatedOn,a.ScheduleId,a.ScheduleState
ORDER BY a.CreatedOn
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].AuditSchedule  WHERE IsDeleted=0

END
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP PROCEDURE GetAuditScheduleListProcedure");
        }
    }
}
