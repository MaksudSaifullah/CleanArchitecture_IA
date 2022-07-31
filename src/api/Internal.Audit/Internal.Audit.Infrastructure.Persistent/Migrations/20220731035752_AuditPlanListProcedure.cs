using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class AuditPlanListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               CREATE OR ALTER Procedure [dbo].[GetAuditPlanListProcedure]
@pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100)
AS
BEGIN
SELECT ap.[Id]
      ,ap.[RiskAssessmentId]
      ,ra.[AssessmentCode]
	  ,cnt.Name As CountryName
	  ,cvt.Text As AuditTypeName
      ,ap.PlanningYearId
	  ,cvta.Text As YearName
      ,ap.[AssessmentFrom]
      ,ap.[AssessmentTo]
      ,ap.[IsDeleted]
  FROM [BranchAudit].[AuditPlan] AS ap
  Inner Join [BranchAudit].[RiskAssessment] as ra on ap.RiskAssessmentId = ra.Id
  Inner Join [common].[Country] as cnt on ra.CountryId = cnt.Id
  Inner Join [Config].[CommonValueAndType] as cvt on ra.AuditTypeId = cvt.Id
  Inner Join [Config].[CommonValueAndType] as cvta on ap.PlanningYearId = cvta.Id
   WHERE ap.[IsDeleted] = 0
	 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (ap.[PlanCode] like '%'+@searchTerm+'%'))	
     ORDER BY ap.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;

	SELECT cast(count(*) as bigint) as TotalCount from[BranchAudit].[AuditPlan] as ap
		where ap.[IsDeleted] = 0
		AND ((@searchTerm IS NULL OR @searchTerm = '') OR (ap.[PlanCode] like '%'+@searchTerm+'%'))
		END

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetAuditPlanListProcedure]");
        }
    }
}
