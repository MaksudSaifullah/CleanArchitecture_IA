using Internal.Audit.Application.Contracts.Persistent.WorkPapers;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.WorkPapers;

public class WorkPaperQueryRepository : QueryRepositoryBase<CompositeWorkPaper>, IWorkPaperQueryRepository
{
    public WorkPaperQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositeWorkPaper>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
    {
        string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
        if (!string.IsNullOrWhiteSpace(searchTermConverted))
        {
            searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
        }
        var query = "EXEC [dbo].[GetWorkPaperListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };
        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositeWorkPaper> GetById(Guid id)
    {
        var query = @"SELECT wp.[Id]
      ,wp.[WorkPaperCode]
	  ,dcmnt.Name as DocumentName 
      ,wp.[AuditScheduleId]
      ,wp.AuditScheduleBranchId
      ,wp.[TopicHeadId]
	  ,th.Name as TopicHeadName
	  ,wp.[QuestionId]
	  ,qus.Question as QuestionName
	  ,th.Name as TopicHeadName
	  , brn.BranchName
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
	  ,wp.TestingDate
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
  --Inner Join BranchAudit.AuditScheduleBranch as adtbr on wp.AuditScheduleBranchId = adtbr.BranchId
  Inner Join security.Branch as brn on  wp.AuditScheduleBranchId = brn.Id 
  Inner Join Config.CommonValueAndType cvtsm on wp.SampleMonthId = cvtsm.Id
  Inner Join Config.CommonValueAndType smpl on wp.SampleSelectionMethodId = smpl.Id
  Inner Join Config.CommonValueAndType cntrl on wp.ControlActivityNatureId = cntrl.Id
  Inner Join Config.CommonValueAndType frqn on wp.ControlFrequencyId = frqn.Id
  Inner Join Config.CommonValueAndType smplsz on wp.SampleSizeId = smplsz.Id
  Inner Join Config.CommonValueAndType cvttc on wp.TestingConclusionId = cvttc.Id
  INNER Join common.Document dcmnt on wp.DocumentId = dcmnt.Id
  WHERE  wp.[Id] = @id AND wp.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

}