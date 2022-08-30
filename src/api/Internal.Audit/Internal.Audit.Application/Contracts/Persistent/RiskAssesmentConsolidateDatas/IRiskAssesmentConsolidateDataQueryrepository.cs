using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Application.Contracts.Persistent.RiskAssesmentConsolidateDatas;

public interface IRiskAssesmentConsolidateDataQueryrepository:IAsyncQueryRepository<RiskAssesmentConsolidateData>
{
    Task<IEnumerable<RiskAssesmentConsolidateData>> GetAllAsync(Guid RiskAssesmentId,Guid CountryId,int pageNumber,int pageSize);
}
