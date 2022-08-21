using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Application.Contracts.Persistent.RiskAssesmentDataManagementLogs;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Domain.CompositeEntities;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.RiskAssesmentDatamanagementLogs;

public class RiskAssesmentDataManagementLogQueryRepository : QueryRepositoryBase<CompositeRiskAssesmentData>, IRiskAssesmentDataManagementLogQueryRepository
{
    public RiskAssesmentDataManagementLogQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    //public Task<IEnumerable<RiskAssesmentDataManagementLog>> GetDataSyncList(Guid? countryId, Guid? riskassesmentId, DateTime? FromDate, DateTime? ToDate, int typeId, decimal conversionRate, int pageNumber, int pageSize)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<IEnumerable<CompositeRiskAssesmentData>> GetDataSyncList(Guid? countryId, Guid? riskassesmentId, DateTime? FromDate, DateTime? ToDate, int typeId, decimal conversionRate, int pageNumber, int pageSize)
    {
        var query = "EXEC [dbo].[GetAmbsDataSyncListRiskassesment] @typeId,@conversionRate,@FromDate,@ToDate,@CountryId,@RiskAssesmentId,@pageNumber,@pageSize";
        var parameters = new Dictionary<string, object> { { "FromDate", FromDate }, { "ToDate", ToDate }, { "CountryId", countryId }, { "typeId", typeId }, { "conversionRate", conversionRate }, { "pageNumber", pageNumber }, { "pageSize", pageSize }, { "RiskAssesmentId", riskassesmentId } };

        string splitters = "TC";
        try
        {
            var dd = await Get(query, parameters);

        }catch (Exception ex) { }
        var data = await Get<CompositeRiskAssesmentData, EfTotalCount, CompositeRiskAssesmentData>(query, (riskassesmentdata, eftotalcount) =>
        {
            CompositeRiskAssesmentData doc;
            doc = riskassesmentdata;
            doc.TotalCount = eftotalcount;         

            return doc;
        }, parameters, splitters, false);
        return data.Distinct();
    }
}
