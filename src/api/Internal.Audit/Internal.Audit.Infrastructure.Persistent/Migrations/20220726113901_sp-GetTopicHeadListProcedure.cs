using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class spGetTopicHeadListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER   PROCEDURE [dbo].[GetTopicHeadListProcedure]
                 @pageSize int,
                 @pageNumber int,
	             @searchTerm nvarchar(100)
            AS
            BEGIN
                   SELECT
	                 topicHead.[Id]
		            ,topicHead.[CountryId]
		            ,topicHead.[Name]
		            ,topicHead.[EffectiveFrom]
		            ,topicHead.[EffectiveTo]
		            ,topicHead.[Description]
                    ,Country.[Name] AS CountryName
        	
		            FROM [BranchAudit].[TopicHead] as topicHead
	                INNER JOIN [common].Country as Country on Country.Id = topicHead.CountryId       
		            WHERE topicHead.IsDeleted = 0
		            AND ((@searchTerm IS NULL OR @searchTerm = '') OR (topicHead.[Name] like '%'+@searchTerm+'%') OR (Country.[Name] like '%'+@searchTerm+'%'))	

                 ORDER BY topicHead.CreatedOn DESC
                 OFFSET((@pageNumber - 1) * @pageSize) ROWS
                 FETCH NEXT @pageSize ROWS ONLY;
             SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[TopicHead] as topicHead
             INNER JOIN [common].Country as Country on Country.Id = topicHead.CountryId
             where topicHead.[IsDeleted]=0 
             AND ((@searchTerm IS NULL OR @searchTerm = '') OR (topicHead.[Name] like '%'+@searchTerm+'%') OR (Country.[Name] like '%'+@searchTerm+'%'))	
            END

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetTopicHeadListProcedure]");
        }
    }
}
