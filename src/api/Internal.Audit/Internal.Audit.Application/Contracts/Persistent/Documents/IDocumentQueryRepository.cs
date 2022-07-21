using Internal.Audit.Domain.Entities.common;

namespace Internal.Audit.Application.Contracts.Persistent.Documents;

public interface IDocumentQueryRepository:IAsyncQueryRepository<Document>
{
    Task<Document> GetByDocumentId(Guid id);
}
