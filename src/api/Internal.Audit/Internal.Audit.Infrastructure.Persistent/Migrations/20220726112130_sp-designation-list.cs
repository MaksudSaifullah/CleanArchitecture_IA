using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class spdesignationlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[GetDesignationListProcedure]
	        @pageSize int,
	        @pageNumber int,
	        @searchTerm nvarchar(100)
	 
            AS
            BEGIN
	            SELECT [Id]
	                ,[Name]
                    ,[Description]
                    ,[IsActive]
                    ,[CreatedBy]
                    ,[CreatedOn]
	                FROM [common].[Designation]
	                WHERE [IsDeleted] = 0
	            AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Designation.Name like '%'+@searchTerm+'%') OR (Designation.Description like '%'+@searchTerm+'%'))	

	                ORDER BY [CreatedOn] DESC
	                OFFSET ((@pageNumber-1) * @pageSize) ROWS
	                FETCH NEXT @pageSize ROWS ONLY;


	            SELECT cast(count(*) as bigint) as TotalCount from [common].[Designation] where [IsDeleted] = 0 
	            AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Designation.Name like '%'+@searchTerm+'%') OR (Designation.Description like '%'+@searchTerm+'%'))	

            END
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetDesignationListProcedure]");
        }
    }
}
