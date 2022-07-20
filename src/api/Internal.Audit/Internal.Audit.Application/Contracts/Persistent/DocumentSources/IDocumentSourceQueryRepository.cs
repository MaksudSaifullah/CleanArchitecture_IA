using Internal.Audit.Domain.Entities.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.DocumentSources;

public interface IDocumentSourceQueryRepository:IAsyncQueryRepository<DocumentSource>
{
    Task<IEnumerable<DocumentSource>> GetAllAsync();
}
