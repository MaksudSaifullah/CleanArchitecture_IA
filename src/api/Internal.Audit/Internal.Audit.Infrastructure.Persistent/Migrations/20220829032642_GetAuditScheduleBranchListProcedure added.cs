using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetAuditScheduleBranchListProcedureadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE   PROCEDURE [dbo].[GetAuditScheduleBranchListProcedure]
@pageSize int,
@pageNumber int,
@scheduleId nvarchar(50)
AS
BEGIN

select a.AuditScheduleId,a.BranchId,b.BranchName,c.Name CountryName
from [BranchAudit].[AuditScheduleBranch] a
inner join security.Branch b on a.BranchId=b.id
inner join common.Country c on b.CountryId=c.Id
WHERE a.AuditScheduleId=@scheduleId and a.IsDeleted=0
ORDER BY a.CreatedOn DESC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[AuditScheduleBranch]
where AuditScheduleId=@scheduleId and IsDeleted=0

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetAuditScheduleBranchListProcedure] ");
        }
    }
}
