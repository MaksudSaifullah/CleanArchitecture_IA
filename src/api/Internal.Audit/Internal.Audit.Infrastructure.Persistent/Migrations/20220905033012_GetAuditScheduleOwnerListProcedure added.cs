using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetAuditScheduleOwnerListProcedureadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE   PROCEDURE [dbo].[GetAuditScheduleOwnerListProcedure]
	    @pageSize int,
	    @pageNumber int,
	    @auditScheduleId nvarchar(50),
		@ownerTypeId int
AS
BEGIN
SELECT  a.AuditScheduleId,b.BranchName, 
STUFF((SELECT  ', ' + CAST(a.UserName AS VARCHAR(50)) [text()]
FROM [security].[User] A
INNER JOIN [BranchAudit].[AuditScheduleConfigurationOwner] B ON a.Id=b.UserId 
AND b.CommonValueAuditScheduleRiskOwnerTypetId=@ownerTypeId
WHERE  a.Id=b.UserId
group by a.Id,UserName order by a.Id
FOR XML PATH(''), TYPE)
.value('.','NVARCHAR(MAX)'),1,2,' ') UserName
FROM [BranchAudit].[AuditScheduleConfigurationOwner] a
INNER JOIN [security].[Branch] b on a.BranchId=b.Id
INNER JOIN [security].[User] u ON a.UserId=u.Id
WHERE a.IsDeleted=0 AND ((@auditScheduleId is null or @auditScheduleId = '') or a.AuditScheduleId like '%'+@auditScheduleId+'%')
AND a.CommonValueAuditScheduleRiskOwnerTypetId=@ownerTypeId
GROUP BY a.AuditScheduleId,b.BranchName
ORDER BY b.BranchName ASC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT  
a.AuditScheduleId,b.BranchName, 
STUFF((SELECT  ', ' + CAST(a.UserName AS VARCHAR(50)) [text()]
FROM [security].[User] A
INNER JOIN [BranchAudit].[AuditScheduleConfigurationOwner] B ON a.Id=b.UserId
WHERE  a.Id=b.UserId
group by a.Id,UserName order by a.Id
FOR XML PATH(''), TYPE)
.value('.','NVARCHAR(MAX)'),1,2,' ') UserName  INTO #TempCount
FROM [BranchAudit].[AuditScheduleConfigurationOwner] a
INNER JOIN [security].[Branch] b on a.BranchId=b.Id
INNER JOIN [security].[User] u ON a.UserId=u.Id
WHERE a.IsDeleted=0 AND ((@auditScheduleId is null or @auditScheduleId = '') or a.AuditScheduleId like '%'+@auditScheduleId+'%')
AND a.CommonValueAuditScheduleRiskOwnerTypetId=@ownerTypeId
GROUP BY a.AuditScheduleId,b.BranchName

select count(*)TotalCount from  #TempCount
drop table #TempCount

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP   PROCEDURE [dbo].[GetAuditScheduleOwnerListProcedure]");
        }
    }
}
