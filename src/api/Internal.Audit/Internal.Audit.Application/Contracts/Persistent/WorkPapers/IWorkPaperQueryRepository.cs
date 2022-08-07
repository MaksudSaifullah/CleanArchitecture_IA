using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.WorkPapers;
public interface IWorkPaperQueryRepository : IAsyncQueryRepository<CompositeWorkPaper>
{
    Task<(long, IEnumerable<CompositeWorkPaper>)> GetAll(int pageSize, int pageNumber, dynamic search = null!);

    Task<CompositeWorkPaper> GetById(Guid id);
}
