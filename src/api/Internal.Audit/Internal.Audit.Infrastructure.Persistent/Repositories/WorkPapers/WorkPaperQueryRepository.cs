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
  WHERE  wp.[Id] = @id AND wp.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

}