using Internal.Audit.Domain.Entities.config;

namespace Internal.Audit.Application.Contracts.Persistent.UploadDocuments;

public interface IUploadDocumentCommandRepository : IAsyncCommandRepository<UploadDocument>
{
}
