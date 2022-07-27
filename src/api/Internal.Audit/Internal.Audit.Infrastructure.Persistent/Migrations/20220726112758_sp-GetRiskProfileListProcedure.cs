using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class spGetRiskProfileListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
               CREATE OR ALTER PROCEDURE [dbo].[GetRiskProfileListProcedure]
                 @pageSize int,
                 @pageNumber int,
	             @searchTerm nvarchar(100)
                    AS
                    BEGIN
                           SELECT
	                         rp.[Id]
	                        ,cvtlt.Text AS LikelihoodType
	                        ,cvtit.Text AS ImpactType
	                        ,cvtrt.Text AS RatingType
                            ,rp.[EffectiveFrom]
                            ,rp.[EffectiveTo]
                            ,rp.[Description]
                            ,rp.[CreatedBy]
                            ,rp.[CreatedOn]
		                    ,rp.[IsActive]
                         FROM[common].[RiskProfile] as rp
	                        INNER JOIN [config].[CommonValueAndType] as cvtlt on cvtlt.Id = rp.LikelihoodTypeId
                            INNER JOIN [config].[CommonValueAndType] as cvtit on cvtit.Id = rp.ImpactTypeId
                            INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rp.RatingTypeId
                         WHERE rp.[IsDeleted] = 0
	                     AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cvtlt.Text like '%'+@searchTerm+'%') OR (cvtit.Text like '%'+@searchTerm+'%') OR (cvtrt.Text like '%'+@searchTerm+'%'))	
                         ORDER BY rp.[CreatedOn] DESC
                         OFFSET((@pageNumber - 1) * @pageSize) ROWS
                         FETCH NEXT @pageSize ROWS ONLY;

                     SELECT cast(count(*) as bigint) as TotalCount from[common].[RiskProfile] as rp
		                    INNER JOIN [config].[CommonValueAndType] as cvtlt on cvtlt.Id = rp.LikelihoodTypeId
                            INNER JOIN [config].[CommonValueAndType] as cvtit on cvtit.Id = rp.ImpactTypeId
                            INNER JOIN [config].[CommonValueAndType] as cvtrt on cvtrt.Id = rp.RatingTypeId
                     where rp.[IsDeleted] = 0
                     AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cvtlt.Text like '%'+@searchTerm+'%') OR (cvtit.Text like '%'+@searchTerm+'%') OR (cvtrt.Text like '%'+@searchTerm+'%'))	
                    END            
                
           ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetRiskProfileListProcedure]");
        }
    }
}
