using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetModulewiseRolePriviliegeByRoleIdListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE or ALTER   PROCEDURE [dbo].[GetModulewiseRolePriviliegeByRoleIdListProcedure]
            @pageSize int,
            @pageNumber int,
            @roleId nvarchar(36)
            AS
            BEGIN
            SELECT [Id]
            ,[AuditModuleId]
            ,[AuditFeatureId]
            ,[RoleId]
            ,[IsView]
            ,[IsCreate]
            ,[IsEdit]
            ,[IsDelete]
            FROM [security].[ModulewiseRolePriviliege]
            WHERE [IsDeleted] = 0 and [RoleId]=@roleId
            ORDER BY [CreatedOn] DESC
            OFFSET ((@pageNumber-1) * @pageSize) ROWS
            FETCH NEXT @pageSize ROWS ONLY;


            SELECT cast(count(*) as bigint) as TotalCount from [security].[ModulewiseRolePriviliege] where [IsDeleted] = 0

            END";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetModulewiseRolePriviliegeByRoleIdListProcedure]");
        }
    }
}
