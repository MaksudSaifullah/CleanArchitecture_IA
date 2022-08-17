using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;

public interface IClosingMeetingMinutesQueryRepository : IAsyncQueryRepository<CompositeClosingMeetingMinutes>
{
    Task<(long, IEnumerable<CompositeClosingMeetingMinutes>)> GetAll(int pageSize, int pageNumber, dynamic search = null!);

    Task<CompositeClosingMeetingMinutes> GetById(Guid id);
}
