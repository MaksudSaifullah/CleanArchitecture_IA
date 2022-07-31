using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class RiskAssessmentListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               CREATE OR ALTER PROCEDURE [dbo].[GetRiskAssessmentListProcedure]
     @pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100),
	 @year nvarchar(50)
AS
BEGIN
				SELECT ra.[Id]
					,ra.AssessmentCode
	                ,cntr.Id AS CountryId
	                ,cvtat.Id AS AuditTypeId
	                ,cntr.Name AS CountryName
	                ,cvtat.Text AS AuditTypeName
                    ,ra.[EffectiveFrom]
                    ,ra.[EffectiveTo]
                    ,ra.[CreatedBy]
                    ,ra.[CreatedOn]
                FROM [BranchAudit].[RiskAssessment] as ra
                INNER JOIN [common].[Country] as cntr on cntr.Id = ra.CountryId
				INNER JOIN [config].[CommonValueAndType] as cvtat on cvtat.Id = ra.AuditTypeId
				 WHERE  ra.IsDeleted = 0
				 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (ra.AssessmentCode like '%'+@searchTerm+'%'))	
				 AND ((@year IS NULL OR @year = '') OR (ra.EffectiveFrom like '%'+@year+'%') OR (ra.EffectiveTo like '%'+@year+'%'))	
				 ORDER BY ra.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
 SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[RiskAssessment] ra 
 
 where [IsDeleted] = 0
 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (ra.AssessmentCode like '%'+@searchTerm+'%'))
 AND ((@year IS NULL OR @year = '') OR (ra.EffectiveFrom like '%'+@year+'%') OR (ra.EffectiveTo like '%'+@year+'%'))
    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetRiskAssessmentListProcedure]");
        }
    }
}
