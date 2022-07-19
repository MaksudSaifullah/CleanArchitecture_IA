using Internal.Audit.Application.Contracts.Persistent.RiskProfiles;
using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskProfiles;
public class RiskProfileQueryRepository : QueryRepositoryBase<CompositeRiskProfile>, IRiskProfileQueryRepository
{
    public RiskProfileQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositeRiskProfile>)> GetAll(int pageSize, int pageNumber)
    {
        var query = "EXEC [dbo].[GetRiskProfileListProcedure] @pageSize,@pageNumber";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
        // var (count, result) = await GetWithPagingInfo(query, parameters, false);
        //return await Get(query);
        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositeRiskProfile> GetById(Guid id)
    {
        var query = @"SELECT ra.[Id]
					,ra.AssesmentCode
	                ,cntr.Id AS CountryId
	                ,cvtat.Id AS AuditTypeId
	                ,cntr.Name AS CountryName
	                ,cvtat.Text AS AuditTypeName
                    ,ra.[EffectiveFrom]
                    ,ra.[EffectiveTo]
                    ,ra.[CreatedBy]
                    ,ra.[CreatedOn]
                FROM [BranchAudit].[RiskAssesment] as ra
                INNER JOIN [common].[Country] as cntr on cntr.Id = ra.CountryId
				INNER JOIN [config].[CommonValueAndType] as cvtat on cvtat.Id = ra.AuditTypeId
				 WHERE ra.[Id] = @id AND ra.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }

}
