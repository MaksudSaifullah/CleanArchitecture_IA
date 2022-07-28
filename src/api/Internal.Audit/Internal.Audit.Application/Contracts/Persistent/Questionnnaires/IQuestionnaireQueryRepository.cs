using Internal.Audit.Domain.CompositeEntities.BranchAudit;


namespace Internal.Audit.Application.Contracts.Persistent.Questionnnaires;

public interface IQuestionnaireQueryRepository : IAsyncQueryRepository<CompositeQuestionnaire>
{
    Task<(long, IEnumerable<CompositeQuestionnaire>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null);
    Task<CompositeQuestionnaire> GetById(Guid id);
}
