using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetRoleListProcedureSearch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE or ALTER PROCEDURE [dbo].[GetRoleListProcedure]
                        @pageSize int,
                        @pageNumber int,
						@searchTerm nvarchar(100)
                        AS
                        BEGIN
                        SELECT [Id]
                        ,[Name]
                        ,[Description]
                        ,[IsActive]
                        FROM [security].[Role]
                        WHERE [IsDeleted] = 0
						AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Role.Name like '%'+@searchTerm+'%') OR (Role.Description like '%'+@searchTerm+'%'))	
                        ORDER BY [CreatedOn] DESC
                        OFFSET((@pageNumber - 1) * @pageSize) ROWS
                        FETCH NEXT @pageSize ROWS ONLY;
                        SELECT cast(count(*) as bigint) as TotalCount from [security].[Role] where [IsDeleted] = 0
						AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Role.Name like '%'+@searchTerm+'%') OR (Role.Description like '%'+@searchTerm+'%'))	
                        END";
            migrationBuilder.Sql(sql);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetRoleListProcedure]");
        }
    }
}
