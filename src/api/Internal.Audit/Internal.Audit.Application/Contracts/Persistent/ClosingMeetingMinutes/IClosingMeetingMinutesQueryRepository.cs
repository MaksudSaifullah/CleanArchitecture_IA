using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;

public interface IClosingMeetingMinutesQueryRepository : IAsyncQueryRepository<CompositeClosingMeetingMinute>
{
    Task<(long, IEnumerable<CompositeClosingMeetingMinute>)> GetAll(int pageSize, int pageNumber, dynamic search = null!);

  // Task<CompositeClosingMeetingMinute> GetById(Guid id);
}
