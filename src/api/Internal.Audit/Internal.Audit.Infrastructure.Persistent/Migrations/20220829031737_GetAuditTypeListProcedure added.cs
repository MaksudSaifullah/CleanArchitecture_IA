using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetAuditTypeListProcedureadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER   PROCEDURE [dbo].[GetAuditTypeListProcedure]
@pageSize int,
@pageNumber int
AS
BEGIN

SELECT *
FROM[Config].[AuditType] a
WHERE a.IsDeleted = 0
ORDER BY a.CreatedOn DESC
OFFSET((@pageNumber - 1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

            SELECT cast(count(*) as bigint) as TotalCount from[Config].[AuditType] where IsDeleted = 0

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP Procedure [dbo].[GetAuditTypeListProcedure]");
        }
    }
}
