using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetCountryListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[GetCountryListProcedure]
     @pageSize int,
     @pageNumber int
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
     ORDER BY[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;
 SELECT cast(count(*) as bigint) as TotalCount from[common].[Country] where[IsDeleted] = 0
END"
);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.GetCountryListProcedure");
        }
    }
}
