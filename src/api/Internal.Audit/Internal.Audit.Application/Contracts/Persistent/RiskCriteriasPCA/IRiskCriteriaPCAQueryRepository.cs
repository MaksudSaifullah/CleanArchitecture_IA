using Internal.Audit.Domain.CompositeEntities.ProcessAndControlAudit;
using Internal.Audit.Domain.Entities.Common;


namespace Internal.Audit.Application.Contracts.Persistent.RiskCriteriasPCA;

public interface IRiskCriteriaPCAQueryRepository : IAsyncQueryRepository<CompositeRiskCriteriaPCA>
{
    Task<(long, IEnumerable<CompositeRiskCriteriaPCA>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null);
    Task<CompositeRiskCriteriaPCA> GetById(Guid id);
}