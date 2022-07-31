using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class UpdateGetAuditListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER PROCEDURE [dbo].[GetAuditListProcedure]
	    @pageSize int,
	    @pageNumber int,
	    @searchTerm nvarchar(50)
AS
BEGIN

SELECT a.Id,a.AuditTypeId,a.CountryId,a.PlanId,a.AuditId,a.AuditName,b.Text[AuditTypeName],c.Name[CountryName],a.Year, a.AuditPeriodFrom,a.AuditPeriodTo,a.CreatedOn
FROM [BranchAudit].[AuditCreation] a
INNER JOIN Config.CommonValueAndType b on a.AuditTypeId=b.Id
INNER JOIN common.Country c on a.CountryId=c.Id
WHERE a.IsDeleted=0 AND ((@searchTerm is null or @searchTerm = '') or a.AuditId like '%'+@searchTerm+'%')
ORDER BY c.CreatedOn DESC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[AuditCreation] where IsDeleted=0

END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[GetAuditListProcedure]
	    @pageSize int,
	    @pageNumber int,
	    @searchTerm nvarchar(50)
AS
BEGIN

SELECT a.Id,a.AuditTypeId,a.CountryId,a.PlanId,a.AuditId,a.AuditName,b.Name[AuditTypeName],c.Name[CountryName],a.Year, a.AuditPeriodFrom,a.AuditPeriodTo,a.CreatedOn
FROM [BranchAudit].[AuditCreation] a
INNER JOIN Config.AuditType b on a.AuditTypeId=b.Id
INNER JOIN common.Country c on a.CountryId=c.Id
WHERE a.IsDeleted=0 AND ((@searchTerm is null or @searchTerm = '') or a.AuditId like '%'+@searchTerm+'%')
ORDER BY c.CreatedOn DESC
OFFSET ((@pageNumber-1) * @pageSize) ROWS
FETCH NEXT @pageSize ROWS ONLY;

SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[AuditCreation] where IsDeleted=0

END");
        }
    }
}
