using Internal.Audit.Domain.CompositeEntities;
using Internal.Audit.Domain.Entities.Common;


namespace Internal.Audit.Application.Contracts.Persistent.RiskCriterias;

public interface IRiskCriteriaQueryRepository : IAsyncQueryRepository<CompositeRiskCriteria>
{
    Task<(long, IEnumerable<CompositeRiskCriteria>)> GetAll(int pageSize, int pageNumber);
    Task<CompositeRiskCriteria> GetById(Guid id);
}