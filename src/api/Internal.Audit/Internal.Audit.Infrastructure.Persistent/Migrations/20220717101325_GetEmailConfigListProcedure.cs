using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetEmailConfigListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE [dbo].[GetEmailConfigListProcedure]
	                            @pageSize int,
	                            @pageNumber int
                                AS
                                BEGIN

                                SELECT * FROM [Config].[EmailConfiguration] a
                                ORDER BY a.EmailTypeId DESC
                                OFFSET ((@pageNumber-1) * @pageSize) ROWS
                                FETCH NEXT @pageSize ROWS ONLY;

                                SELECT cast(count(*) as bigint) as TotalCount from [Config].[EmailConfiguration]

                                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE dbo.[GetEmailConfigListProcedure] ");
        }
    }
}
