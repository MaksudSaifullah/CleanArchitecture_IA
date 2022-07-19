using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetEmailTypeListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[GetEmailTypeListProcedure]
	                                 @pageSize int,
	                                 @pageNumber int
                                AS
                                BEGIN

                                SELECT *
                                FROM [Config].[EmailType] a
                                WHERE a.IsDeleted=0
                                ORDER BY Id DESC
                                OFFSET ((@pageNumber-1) * @pageSize) ROWS
                                FETCH NEXT @pageSize ROWS ONLY;

                                SELECT cast(count(*) as bigint) as TotalCount from [Config].[EmailType]

                                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetEmailTypeListProcedure] ");
        }
    }
}
