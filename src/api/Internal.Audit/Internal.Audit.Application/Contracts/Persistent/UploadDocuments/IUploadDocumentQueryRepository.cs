using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.UploadDocuments;

public interface IUploadDocumentQueryRepository : IAsyncQueryRepository<UploadDocument>
{
    Task<IEnumerable<UploadDocument>> GetAllAsyncByRoleId(Guid RoleId, int pageSize, int pageNumber);
}
