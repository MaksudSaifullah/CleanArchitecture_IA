using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class GetWorkPaperListProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"Create or ALTER Procedure [dbo].[GetWorkPaperListProcedure]
@pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100)
AS
BEGIN
SELECT wp.[Id]
      ,wp.[WorkPaperCode]
	  ,th.Name
      ,wp.[TopicHeadId]
      ,wp.[SampleName]
	  ,cvtsm.Text As SampleMonth
      ,wp.[SampleMonthId]
	  ,cvttc.Text As TestingConclusion
      ,wp.[TestingConclusionId]
	  ,dcmnt.Name As DocumentName
      ,wp.[DocumentId]
      ,wp.[CommonValueAndTypeId]
  FROM [BranchAudit].[WorkPaper] as wp
  Inner Join BranchAudit.TopicHead th on wp.TopicHeadId = th.Id
  Inner Join Config.CommonValueAndType cvtsm on wp.SampleMonthId = cvtsm.Id
  Inner Join Config.CommonValueAndType cvttc on wp.TestingConclusionId = cvttc.Id
  Inner Join common.Document dcmnt on wp.DocumentId = dcmnt.Id
   WHERE wp.[IsDeleted] = 0
	 AND ((@searchTerm IS NULL OR @searchTerm = '') OR (th.Name like '%'+@searchTerm+'%'))	
     ORDER BY wp.[CreatedOn] DESC
     OFFSET((@pageNumber - 1) * @pageSize) ROWS
     FETCH NEXT @pageSize ROWS ONLY;

	SELECT cast(count(*) as bigint) as TotalCount from[BranchAudit].[WorkPaper] as wp
		  Inner Join BranchAudit.TopicHead th on wp.TopicHeadId = th.Id
		where wp.[IsDeleted] = 0
		AND ((@searchTerm IS NULL OR @searchTerm = '') OR (th.Name like '%'+@searchTerm+'%'))

		END


		--Exec [GetWorkPaperListProcedure] '10','1', 'Topic'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP Procedure [dbo].[GetWorkPaperListProcedure]");
        }
    }
}
