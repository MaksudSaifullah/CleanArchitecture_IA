using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetAuditScheduleListProcedureupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER   PROCEDURE [dbo].[GetAuditScheduleListProcedure]
@pageSize int,
@pageNumber int,
@scheduleId nvarchar(50),
@auditCreationId nvarchar(50)
AS
BEGIN


SELECT distinct  a.Id, c.Name Country,a.ScheduleId,a.ScheduleState,a.ExecutionState,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE  x.AuditScheduleId=a.id and  x.UserId=y.Id and x.CommonValueParticipantId=1
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) Approver,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.AuditScheduleId=a.id and x.UserId=y.Id and x.CommonValueParticipantId=2
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) TeamLeader,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.AuditScheduleId=a.id and x.UserId=y.Id and x.CommonValueParticipantId=3
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) Auditor,
	a.ScheduleStartDate,
	a.ScheduleEndDate,
a.CreatedOn
FROM [BranchAudit].AuditSchedule a
INNER JOIN [BranchAudit].[AuditCreation] ac on a.AuditCreationId=ac.Id
INNER JOIN [BranchAudit].[AuditPlan] ap on ac.AuditPlanId=ap.Id
INNER JOIN [BranchAudit].[RiskAssessment] ra on ap.RiskAssessmentId=ra.Id
INNER JOIN [common].[Country] c on ra.CountryId=c.Id
INNER JOIN [BranchAudit].[AuditScheduleParticipants] asp on a.Id=asp.AuditScheduleId
INNER JOIN [security].[User] u on asp.UserId=u.Id

WHERE a.AuditCreationId=@auditCreationId and  a.IsDeleted=0 AND ((@scheduleId is null or @scheduleId = '') or a.ScheduleId like '%'+@scheduleId+'%')
GROUP BY a.Id,u.Id, c.Name,u.UserName,a.ScheduleEndDate,a.ScheduleStartDate,a.CreatedOn,a.ScheduleId,a.ScheduleState,a.ExecutionState
ORDER BY a.CreatedOn desc
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].AuditSchedule 
WHERE AuditCreationId=@auditCreationId and IsDeleted=0

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"ALTER   PROCEDURE [dbo].[GetAuditScheduleListProcedure]
@pageSize int,
@pageNumber int,
@scheduleId nvarchar(50),
@auditCreationId nvarchar(50)
AS
BEGIN


SELECT distinct  a.Id, c.Name Country,a.ScheduleId,a.ScheduleState,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE  x.AuditScheduleId=a.id and  x.UserId=y.Id and x.CommonValueParticipantId=1
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) Approver,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.AuditScheduleId=a.id and x.UserId=y.Id and x.CommonValueParticipantId=2
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) TeamLeader,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.AuditScheduleId=a.id and x.UserId=y.Id and x.CommonValueParticipantId=3
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) Auditor,
	a.ScheduleStartDate,
	a.ScheduleEndDate,
a.CreatedOn
FROM [BranchAudit].AuditSchedule a
INNER JOIN [BranchAudit].[AuditCreation] ac on a.AuditCreationId=ac.Id
INNER JOIN [BranchAudit].[AuditPlan] ap on ac.AuditPlanId=ap.Id
INNER JOIN [BranchAudit].[RiskAssessment] ra on ap.RiskAssessmentId=ra.Id
INNER JOIN [common].[Country] c on ra.CountryId=c.Id
INNER JOIN [BranchAudit].[AuditScheduleParticipants] asp on a.Id=asp.AuditScheduleId
INNER JOIN [security].[User] u on asp.UserId=u.Id

WHERE a.AuditCreationId=@auditCreationId and  a.IsDeleted=0 AND ((@scheduleId is null or @scheduleId = '') or a.ScheduleId like '%'+@scheduleId+'%')
GROUP BY a.Id,u.Id, c.Name,u.UserName,a.ScheduleEndDate,a.ScheduleStartDate,a.CreatedOn,a.ScheduleId,a.ScheduleState
ORDER BY a.CreatedOn desc
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].AuditSchedule 
WHERE AuditCreationId=@auditCreationId and IsDeleted=0

END");
		}
    }
}
