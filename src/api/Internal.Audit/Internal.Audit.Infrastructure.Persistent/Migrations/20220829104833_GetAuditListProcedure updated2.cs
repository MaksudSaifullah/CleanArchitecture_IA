using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetAuditListProcedureupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER   PROCEDURE [dbo].[GetAuditListProcedure]
	    @pageSize int,
	    @pageNumber int,
	    @searchTerm nvarchar(50)
AS
BEGIN

SELECT  a.Id,a.AuditTypeId,ra.CountryId,ap.PlanCode as PlanId,a.AuditId,a.AuditName,b.Name[AuditTypeName],c.Name[CountryName],
a.Year, a.AuditPeriodFrom,a.AuditPeriodTo,a.CreatedOn
FROM [BranchAudit].[AuditCreation] a
INNER JOIN [BranchAudit].AuditPlan ap on a.AuditPlanId=ap.Id
INNER JOIN [BranchAudit].[RiskAssessment] ra on ap.RiskAssessmentId=ra.Id
INNER JOIN [Config].[AuditType] b on a.AuditTypeId=b.Id
INNER JOIN common.Country c on ra.CountryId=c.Id
WHERE a.IsDeleted=0 AND ((@searchTerm is null or @searchTerm = '') or a.AuditId like '%'+@searchTerm+'%')
ORDER BY c.CreatedOn DESC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[AuditCreation] where IsDeleted=0

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER   PROCEDURE [dbo].[GetAuditListProcedure]
	    @pageSize int,
	    @pageNumber int,
	    @searchTerm nvarchar(50)
AS
BEGIN

SELECT  a.Id,a.AuditTypeId,ra.CountryId,ap.PlanCode as PlanId,a.AuditId,a.AuditName,b.Text[AuditTypeName],c.Name[CountryName],
a.Year, a.AuditPeriodFrom,a.AuditPeriodTo,a.CreatedOn,IIF(aa.Id is not null,1,0) ScheduleExists
FROM [BranchAudit].[AuditCreation] a
INNER JOIN [BranchAudit].AuditPlan ap on a.AuditPlanId=ap.Id
INNER JOIN [BranchAudit].[RiskAssessment] ra on ap.RiskAssessmentId=ra.Id
INNER JOIN Config.CommonValueAndType b on a.AuditTypeId=b.Id
INNER JOIN common.Country c on ra.CountryId=c.Id
LEFT JOIN [BranchAudit].[AuditSchedule] aa on aa.AuditCreationId=a.Id
WHERE a.IsDeleted=0 AND ((@searchTerm is null or @searchTerm = '') or a.AuditId like '%'+@searchTerm+'%')
ORDER BY c.CreatedOn DESC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[AuditCreation] where IsDeleted=0

END");
        }
    }
}
