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
	                                 @pageNumber int,
	                                 @searchTerm nvarchar(50)
                                AS
                                BEGIN

                                SELECT a.Id,a.EmailTypeId,a.CountryId,b.Name[EmailTypeName],c.Name[CountryName],a.TemplateSubject,a.TemplateBody,a.CreatedOn
                                FROM [Config].[EmailConfiguration] a
                                INNER JOIN Config.EmailType b on a.EmailTypeId=b.Id
                                INNER JOIN common.Country c on a.CountryId=c.Id
                                WHERE a.IsDeleted=0 AND ((@searchTerm is null or @searchTerm = '') or c.[Name] like '%'+@searchTerm+'%')
                                ORDER BY c.Name ASC
                                OFFSET ((@pageNumber-1) * @pageSize) ROWS
                                FETCH NEXT @pageSize ROWS ONLY;

                                SELECT cast(count(*) as bigint) as TotalCount from [Config].[EmailConfiguration]

                                END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetEmailConfigListProcedure] ");
        }
    }
}
