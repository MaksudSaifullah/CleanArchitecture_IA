using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class CountrySearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE OR ALTER PROCEDURE [dbo].[GetCountryListProcedure]
     @pageSize int,
     @pageNumber int,
	  @searchTerm nvarchar(100)
AS
BEGIN
       SELECT
       [Id]
      ,[Name]
      ,[Code]
      ,[Remarks]
      ,[CreatedBy]
      ,[CreatedOn]
     FROM[common].[Country]
     WHERE[IsDeleted] = 0
	 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Country.Code like '%'+@searchTerm+'%'))	
     ORDER BY[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
 SELECT cast(count(*) as bigint) as TotalCount from[common].[Country] where[IsDeleted] = 0
 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Country.Code like '%'+@searchTerm+'%'))	
END";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetCountryListProcedure]");
        }
    }
}
