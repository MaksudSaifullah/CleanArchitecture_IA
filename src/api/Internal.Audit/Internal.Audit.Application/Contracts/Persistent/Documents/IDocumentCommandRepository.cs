using Internal.Audit.Domain.Entities.common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;

namespace Internal.Audit.Application.Contracts.Persistent.Documents;

public interface IDocumentCommandRepository : IAsyncCommandRepository<Document>
{
    Task<(bool,string,string)> UploadFile(IFormFile file,string sourceName);
}
