using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.Checklists;

public interface IChecklistQueryRepository : IAsyncQueryRepository<CompositeChecklist>
{
    Task<(long, IEnumerable<CompositeChecklist>)> GetAll(int pageSize, int pageNumber, dynamic search = null!);

   // Task<CompositeChecklist> GetById(Guid id);
}
