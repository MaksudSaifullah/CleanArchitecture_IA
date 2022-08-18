using Internal.Audit.Application.Contracts.Persistent.UploadDocuments;
using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.UploadDocuments;

public class UploadDocumentQueryRepository : QueryRepositoryBase<UploadDocument>, IUploadDocumentQueryRepository
{
    public UploadDocumentQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public  async Task<IEnumerable<UploadDocument>> GetAllAsyncByRoleId(Guid RoleId)
    {
        throw new NotImplementedException();
    }
}
