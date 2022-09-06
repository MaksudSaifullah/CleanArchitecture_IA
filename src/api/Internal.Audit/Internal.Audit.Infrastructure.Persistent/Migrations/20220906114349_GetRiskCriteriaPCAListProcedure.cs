using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetRiskCriteriaPCAListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetRiskCriteriaPCAListProcedure]
                                  @pageSize int,
                                  @pageNumber int,
	                              @searchTerm nvarchar(100)
                                  AS
                                  BEGIN
                                        SELECT rc.[Id]
                                            ,cntr.Id AS [CountryId]
                                            ,cntr.Name AS [CountryName]
	                                        ,rc.[Name]
		                                    ,rc.[Weight]
                                            ,rc.[EffectiveFrom]
                                            ,rc.[EffectiveTo]
                                            ,rc.[Description]
                                            FROM [ProcessAndControlAudit].[RiskCriteria] as rc
	                                        INNER JOIN [common].[Country] as cntr on cntr.Id = rc.CountryId
                                            WHERE  rc.IsDeleted = 0
	                                     AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cntr.[Name] like '%'+@searchTerm+'%'))	
                                         ORDER BY rc.[CreatedOn] DESC
                                         OFFSET((@pageNumber - 1) * @pageSize) ROWS
                                         FETCH NEXT @pageSize ROWS ONLY;

	                                     SELECT cast(count(*) as bigint) as TotalCount from [ProcessAndControlAudit].[RiskCriteria] as rc
		                                    INNER JOIN [common].[Country] as cntr on cntr.Id = rc.CountryId 
		                                    where rc.[IsDeleted] = 0
		                                    AND ((@searchTerm IS NULL OR @searchTerm = '')  OR (cntr.[Name] like '%'+@searchTerm+'%'))
		                                    END

                                  ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER   PROCEDURE [dbo].[GetRiskCriteriaPCAListProcedure]
                                  @pageSize int,
                                  @pageNumber int,
	                              @searchTerm nvarchar(100)
                                  AS
                                  BEGIN
                                        SELECT rc.[Id]
                                            ,cntr.Id AS [CountryId]
                                            ,cntr.Name AS [CountryName]
	                                        ,rc.[Name]
		                                    ,rc.[Weight]
                                            ,rc.[EffectiveFrom]
                                            ,rc.[EffectiveTo]
                                            ,rc.[Description]
                                            FROM [ProcessAndControlAudit].[RiskCriteria] as rc
	                                        INNER JOIN [common].[Country] as cntr on cntr.Id = rc.CountryId
                                            WHERE  rc.IsDeleted = 0
	                                     AND ((@searchTerm IS NULL OR @searchTerm = '') OR (cntr.[Name] like '%'+@searchTerm+'%'))	
                                         ORDER BY rc.[CreatedOn] DESC
                                         OFFSET((@pageNumber - 1) * @pageSize) ROWS
                                         FETCH NEXT @pageSize ROWS ONLY;

	                                     SELECT cast(count(*) as bigint) as TotalCount from [ProcessAndControlAudit].[RiskCriteria] as rc
		                                    INNER JOIN [common].[Country] as cntr on cntr.Id = rc.CountryId 
		                                    where rc.[IsDeleted] = 0
		                                    AND ((@searchTerm IS NULL OR @searchTerm = '')  OR (cntr.[Name] like '%'+@searchTerm+'%'))
		                                    END

                                  ");
        }
    }
}
