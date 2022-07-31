using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class SPGetTestStepListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER   PROCEDURE [dbo].[GetTestStepListProcedure]
				 @pageSize int,
				 @pageNumber int,
				 @searchTerm nvarchar(100)
					AS
					BEGIN
						   SELECT
								 TestStep.[Id]
								,Questionnaire.Question AS Questionnaire
								,TopicHead.Name AS TopicHead
								,Country.Name AS Country
								,TestStep.TestStepDetails
								,TestStep.EffectiveFrom
								,TestStep.EffectiveTo
								
						 FROM [BranchAudit].[TestStep]
							 INNER JOIN BranchAudit.Questionnaire on TestStep.QuestionnaireId = Questionnaire.Id
							 INNER JOIN BranchAudit.TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
							 INNER JOIN common.Country on Country.Id = TopicHead.CountryId
							 WHERE TestStep.IsDeleted = 0

							 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Questionnaire.Question like '%'+@searchTerm+'%') OR (TopicHead.Name like '%'+@searchTerm+'%') OR (TestStep.TestStepDetails like '%'+@searchTerm+'%'))	
							 ORDER BY TestStep.[CreatedOn] DESC
							 OFFSET((@pageNumber - 1) * @pageSize) ROWS
							 FETCH NEXT @pageSize ROWS ONLY;

					 SELECT cast(count(*) as bigint) as TotalCount from [BranchAudit].[TestStep]
              INNER JOIN BranchAudit.Questionnaire on TestStep.QuestionnaireId = Questionnaire.Id
							INNER JOIN BranchAudit.TopicHead on TopicHead.Id = Questionnaire.TopicHeadId
							INNER JOIN common.Country on Country.Id = TopicHead.CountryId
							WHERE TestStep.IsDeleted = 0
							AND ((@searchTerm IS NULL OR @searchTerm = '') OR (Country.Name like '%'+@searchTerm+'%') OR (Questionnaire.Question like '%'+@searchTerm+'%') OR (TopicHead.Name like '%'+@searchTerm+'%') OR (TestStep.TestStepDetails like '%'+@searchTerm+'%'))	
					END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[GetTestStepListProcedure]");
        }
    }
}
