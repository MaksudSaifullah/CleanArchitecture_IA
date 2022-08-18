using Internal.Audit.Application.Contracts.Persistent.UploadDocuments;
using Internal.Audit.Domain.Entities.config;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UploadDocuments;

public class UploadDocumentCommandRepository : CommandRepositoryBase<UploadDocument>, IUploadDocumentCommandRepository
{
    public UploadDocumentCommandRepository(InternalAuditContext dbContext) : base(dbContext)
    {
    }
}
