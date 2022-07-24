using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class UpdateRoleProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"CREATE or ALTER PROCEDURE [GetRoleListProcedure]
                        @pageSize int,
                        @pageNumber int
                        AS
                        BEGIN
                        SELECT [Id]
                        ,[Name]
                        ,[Description]
                        ,[IsActive]
                        FROM [security].[Role]
                        WHERE [IsDeleted] = 0
                        ORDER BY [CreatedOn] DESC
                        OFFSET((@pageNumber - 1) * @pageSize) ROWS
                        FETCH NEXT @pageSize ROWS ONLY;
                        SELECT cast(count(*) as bigint) as TotalCount from [security].[Role] where [IsDeleted] = 0
                        END";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP PROCEDURE [dbo].[GetRoleListProcedure]";
            migrationBuilder.Sql(sql);
        }
    }
}
