using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ClosingMeetingMinutes;

public class ClosingMeetingPresentQueryRepository : QueryRepositoryBase<ClosingMeetingPresent>, IClosingMeetingPresentQueryRepository
{
    public ClosingMeetingPresentQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<ClosingMeetingPresent>> GetAllPresentListByCMMId(Guid cmmId)
    {
        var query = @"select * from BranchAudit.ClosingMeetingPresents where ClosingMeetingMinutesId =@cmmId";
        var parameters = new Dictionary<string, object> { { "cmmId", cmmId } };
        return await Get(query, parameters);
    }
}
