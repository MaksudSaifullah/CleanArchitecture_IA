using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentConsolidateDatas;
using Internal.Audit.Domain.CompositeEntities;
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

    public async  Task<IEnumerable<RiskAssesmentConsolidateData>> GetAllAsync(Guid RiskAssesmentId,Guid CountryId,int PageNumber,int PageSize)
    {
        var query = "EXEC [dbo].[BA_RiskAssesment_Consolidate] @countryid,@riskassesmentid,@pageNumber,@pageSize";
        var parameters = new Dictionary<string, object> { { "countryid", CountryId }, { "riskassesmentid", RiskAssesmentId }, { "pageNumber", PageNumber }, { "pageSize", PageSize } };
        string splitters = "TC";

        var data = await Get<RiskAssesmentConsolidateData, EfTotalCount, RiskAssesmentConsolidateData>(query, (dataconsolidate, totalcount) =>
        {
            RiskAssesmentConsolidateData u;
            u = dataconsolidate;
            u.TotalCount= totalcount;
            return u;
        }, parameters, splitters, false);
        var final = data.Distinct();
        return final;
        //return await Get(query, parameters);
    }
}
