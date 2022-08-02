using Internal.Audit.Application.Contracts.Persistent.AuditPlans;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditPlans;
public class AuditPlanQueryRepository : QueryRepositoryBase<CompositeAuditPlan>, IAuditPlanQueryRepository
{
    public AuditPlanQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositeAuditPlan>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
    {
        string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
        if (!string.IsNullOrWhiteSpace(searchTermConverted))
        {
            searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
        }
        var query = "EXEC [dbo].[GetAuditPlanListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };
        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositeAuditPlan> GetById(Guid id)
    {
        var query = @"SELECT ap.[Id]
      ,ap.[RiskAssessmentId]
      ,ra.[AssessmentCode]
      ,ap.[PlanCode]
	  ,cnt.Id As CountryId
	  ,cvt.Id As AuditTypeId
	  ,cnt.Name As CountryName
	  ,cvt.Text As AuditTypeName
      ,ap.PlanningYearId
	  ,cvta.Text As YearName
      ,ap.[AssessmentFrom]
      ,ap.[AssessmentTo]
      ,ap.[IsDeleted]
  FROM [BranchAudit].[AuditPlan] AS ap
  Inner Join [BranchAudit].[RiskAssessment] as ra on ap.RiskAssessmentId = ra.Id
  Inner Join [common].[Country] as cnt on ra.CountryId = cnt.Id
  Inner Join [Config].[CommonValueAndType] as cvt on ra.AuditTypeId = cvt.Id
  Inner Join [Config].[CommonValueAndType] as cvta on ap.PlanningYearId = cvta.Id
  WHERE  ap.[Id] = @id AND ap.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

}