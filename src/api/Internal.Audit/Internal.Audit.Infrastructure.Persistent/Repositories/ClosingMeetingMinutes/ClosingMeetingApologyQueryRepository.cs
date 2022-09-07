using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ClosingMeetingMinutes;


public class ClosingMeetingApologyQueryRepository : QueryRepositoryBase<ClosingMeetingApology>, IClosingMeetingApologyQueryRepository
{
    public ClosingMeetingApologyQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<ClosingMeetingApology>> GetAllMeetingApologyListByMeetingMinutesId(Guid minutesId)
    {
        var query = @"select * from BranchAudit.ClosingMeetingApologies where ClosingMeetingMinutesId =@cmmId";
        var parameters = new Dictionary<string, object> { { "cmmId", minutesId } };
        return await Get(query, parameters);
    }
}
