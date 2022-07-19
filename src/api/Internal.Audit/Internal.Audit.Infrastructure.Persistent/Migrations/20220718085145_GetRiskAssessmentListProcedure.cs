using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetRiskAssessmentListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[GetRiskAssessmentListProcedure]
     @pageSize int,
     @pageNumber int
AS
BEGIN
				SELECT ra.[Id]
					,ra.AssesmentCode
	                ,cntr.Id AS CountryId
	                ,adtp.Id AS AuditTypeId
	                ,cntr.Name AS CountryName
	                ,adtp.Name AS AuditTypeName
                    ,ra.[EffectiveFrom]
                    ,ra.[EffectiveTo]
                    ,ra.[CreatedBy]
                    ,ra.[CreatedOn]
                FROM [BranchAudit].[RiskAssesment] as ra
                INNER JOIN [common].[Country] as cntr on cntr.Id = ra.CountryId
                INNER JOIN [Config].[AuditType] as adtp on adtp.Id = ra.AuditTypeId
				 WHERE  ra.IsDeleted = 0 ORDER BY ra.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
 SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[RiskAssesment] where [IsDeleted] = 0
END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.GetRiskAssessmentListProcedure");
        }
    }
}
