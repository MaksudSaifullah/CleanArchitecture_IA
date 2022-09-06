using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class SPGetAuditScheduleBranchListProcedureAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetAuditScheduleBranchListProcedure]
@pageSize int,
@pageNumber int,
@scheduleId nvarchar(50)
AS
BEGIN

select  a.AuditScheduleId,a.BranchId,b.BranchName,c.Name CountryName,
STUFF((SELECT  distinct ', ' + CAST(y.UserName AS VARCHAR(50)) [text()]
FROM [BranchAudit].[AuditScheduleConfigurationOwner] x
inner join [security].[User] y on  x.UserId=y.id 
WHERE CommonValueAuditScheduleRiskOwnerTypetId=1 and AuditScheduleId=@scheduleId
group by y.UserName
FOR XML PATH(''), TYPE)
.value('.','NVARCHAR(MAX)'),1,2,' ') Auditee


from [BranchAudit].[AuditScheduleBranch] a
left join [BranchAudit].[AuditScheduleConfigurationOwner] so on a.AuditScheduleId=so.AuditScheduleId
inner join security.Branch b on a.BranchId=b.id
inner join common.Country c on b.CountryId=c.Id
WHERE a.AuditScheduleId=@scheduleId and a.IsDeleted=0
group by a.AuditScheduleId,a.BranchId,b.BranchName,c.Name
ORDER BY b.BranchName ASC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[AuditScheduleBranch]
where AuditScheduleId=@scheduleId and IsDeleted=0

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE GetAuditScheduleBranchListProcedure");
        }
    }
}
