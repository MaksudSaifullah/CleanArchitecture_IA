using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class spGetQuestionnaireListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE [dbo].[GetQuestionnaireListProcedure]
				 @pageSize int,
				 @pageNumber int,
				 @searchTerm nvarchar(100)
					AS
					BEGIN
						   SELECT
								 Questionnaire.[Id]
								,TopicHead.Name AS TopicHead
								,Country.Name AS Country
								,Questionnaire.Question
								,Questionnaire.EffectiveFrom
								,Questionnaire.EffectiveTo
								,Questionnaire.IsActive
						 FROM BranchAudit.Questionnaire as Questionnaire
							 INNER JOIN BranchAudit.TopicHead as TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
							 INNER JOIN common.Country as Country on Country.Id = TopicHead.CountryId
							 WHERE Questionnaire.IsDeleted = 0
							 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Questionnaire.Question like '%'+@searchTerm+'%') OR (TopicHead.Name like '%'+@searchTerm+'%'))	
							 ORDER BY Questionnaire.[CreatedOn] DESC
							 OFFSET((@pageNumber - 1) * @pageSize) ROWS
							 FETCH NEXT @pageSize ROWS ONLY;

					 SELECT cast(count(*) as bigint) as TotalCount from BranchAudit.Questionnaire as Questionnaire
							INNER JOIN BranchAudit.TopicHead as TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
							INNER JOIN common.Country as Country on Country.Id = TopicHead.CountryId
							WHERE Questionnaire.IsDeleted = 0
							AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Questionnaire.Question like '%'+@searchTerm+'%') OR (TopicHead.Name like '%'+@searchTerm+'%'))	
					END

            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetQuestionnaireListProcedure]");
		}
    }
}
