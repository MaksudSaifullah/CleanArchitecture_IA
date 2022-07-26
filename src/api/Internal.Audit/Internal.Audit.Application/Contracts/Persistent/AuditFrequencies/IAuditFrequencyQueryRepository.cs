using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.AuditFrequencies;


public interface IAuditFrequencyQueryRepository : IAsyncQueryRepository<CompositeAuditFrequency>
{
Task<(long, IEnumerable<CompositeAuditFrequency>)> GetAll(int pageSize, int pageNumber);
Task<CompositeAuditFrequency> GetById(Guid id);
}