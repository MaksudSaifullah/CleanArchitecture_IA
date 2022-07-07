using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Common;


namespace Internal.Audit.Application.Contracts.Persistent.RiskProfiles;

public interface IRiskProfileQueryRepository : IAsyncQueryRepository<CompositeRiskProfile>
{
    Task<(long, IEnumerable<CompositeRiskProfile>)> GetAll(int pageSize, int pageNumber);
    Task<CompositeRiskProfile> GetById(Guid id);
}