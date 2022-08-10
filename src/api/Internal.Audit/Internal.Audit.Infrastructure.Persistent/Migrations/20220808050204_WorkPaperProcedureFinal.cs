using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internal.Audit.Infrastructure.Persistent.Migrations
{
    public partial class WorkPaperProcedureFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER Procedure [dbo].[GetWorkPaperListProcedure]
@pageSize int,
     @pageNumber int,
	 @searchTerm nvarchar(100)
AS
BEGIN
SELECT wp.[Id]
      ,wp.[WorkPaperCode]
      ,wp.[AuditScheduleId]
      ,wp.[TopicHeadId]
	  ,th.Name as TopicHeadName
	  ,wp.[QuestionId]
	  ,qus.Question as QuestionName
	  ,th.Name as TopicHeadName
      ,wp.[BranchId]
	  ,brnc.BranchName 
      ,wp.[SampleName]
      ,wp.[SampleMonthId]
	  ,cvtsm.Text as SampleMonth
      ,wp.[SampleSelectionMethodId]
	  ,smpl.Text as SampleSelectionMethod
      ,wp.[ControlActivityNatureId]
	  ,cntrl.Text as ControlActivityNature
      ,wp.[ControlFrequencyId]
	  ,frqn.Text as ControlFrequency
      ,wp.[SampleSizeId]
	  ,smplsz.Text as SampleSize
      ,wp.[TestingDetails]
      ,wp.[TestingResults]
      ,wp.[TestingConclusionId]
	  ,cvttc.Text As TestingConclusion
      ,wp.[DocumentId]
	  ,dcmnt.Name As DocumentName
      ,wp.[CommonValueAndTypeId]
      ,wp.[CreatedBy]
      ,wp.[CreatedOn]
      ,wp.[UpdatedBy]
      ,wp.[UpdatedOn]
      ,wp.[ReviewedBy]
      ,wp.[ReviewedOn]
      ,wp.[ApprovedBy]
      ,wp.[ApprovedOn]
      ,wp.[IsDeleted]
  FROM [BranchAudit].[WorkPaper] as wp
  Inner Join BranchAudit.AuditSchedule as adtsdl on wp.AuditScheduleId = adtsdl.Id
  Inner Join BranchAudit.TopicHead as th on wp.TopicHeadId = th.Id
  Inner Join BranchAudit.Questionnaire as qus on wp.QuestionId = qus.Id
  Inner Join security.Branch as brnc on wp.BranchId = brnc.Id
  Inner Join Config.CommonValueAndType cvtsm on wp.SampleMonthId = cvtsm.Id
  Inner Join Config.CommonValueAndType smpl on wp.SampleSelectionMethodId = smpl.Id
  Inner Join Config.CommonValueAndType cntrl on wp.ControlActivityNatureId = cntrl.Id
  Inner Join Config.CommonValueAndType frqn on wp.ControlFrequencyId = frqn.Id
  Inner Join Config.CommonValueAndType smplsz on wp.SampleSizeId = smplsz.Id
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
            migrationBuilder.Sql(@"DROP Procedure [dbo].[GetWorkPaperListProcedure] ");
        }
    }
}
