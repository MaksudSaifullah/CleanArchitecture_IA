using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentConsolidateDatas;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssesmentConsolidateDatas;

public class RiskAssesmentConsolidateDataQueryRepository : QueryRepositoryBase<RiskAssesmentConsolidateData>, IRiskAssesmentConsolidateDataQueryrepository
{
    public RiskAssesmentConsolidateDataQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async  Task<IEnumerable<RiskAssesmentConsolidateData>> GetAllAsync(Guid RiskAssesmentId,Guid CountryId)
    {
        var query = "EXEC [dbo].[BA_RiskAssesment_Consolidate] @countryid,@riskassesmentid";
        var parameters = new Dictionary<string, object> { { "countryid", CountryId }, { "riskassesmentid", RiskAssesmentId } };
        return await Get(query, parameters);
    }
}
