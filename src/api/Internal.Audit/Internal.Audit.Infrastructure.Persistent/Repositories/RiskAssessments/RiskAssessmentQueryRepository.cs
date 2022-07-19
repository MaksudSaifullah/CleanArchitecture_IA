using Internal.Audit.Application.Contracts.Persistent.RiskAssessments;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssessments;
public class RiskAssessmentQueryRepository : QueryRepositoryBase<CompositeRiskAssessment>, IRiskAssessmentQueryRepository
{
    public RiskAssessmentQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositeRiskAssessment>)> GetAll(int pageSize, int pageNumber)
    {
        var query = "EXEC [dbo].[GetRiskAssessmentListProcedure] @pageSize,@pageNumber";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositeRiskAssessment> GetById(Guid id)
    {
        var query = @"SELECT ra.[Id]
					,ra.AssesmentCode
	                ,cntr.Id AS CountryId
	                ,adtp.Id AS AuditTypeId
	                ,cntr.Name AS CountryName
	                ,adtp.Name AS AuditTypeName
                    ,ra.[EffectiveFrom]
                    ,ra.[EffectiveTo]
                    ,ra.[CreatedBy]
                    ,ra.[CreatedOn]
                FROM [BranchAudit].[RiskAssesment] as ra
                INNER JOIN [common].[Country] as cntr on cntr.Id = ra.CountryId
                INNER JOIN [Config].[AuditType] as adtp on adtp.Id = ra.AuditTypeId
				 WHERE ra.[Id] = @id AND ra.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

}