using Internal.Audit.Application.Contracts.Persistent.DocumentSources;
using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.DocumentSources;

public class DocumentSourceQueryRepository : QueryRepositoryBase<DocumentSource>, IDocumentSourceQueryRepository
{
    public DocumentSourceQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<DocumentSource>> GetAllAsync()
    {
        var query = @"SELECT [Id],[Name] FROM [InternalAuditDb].[Config].[DocumentSource] where isactive=1 and isdeleted=0";
        return await Get(query);
    }
}
