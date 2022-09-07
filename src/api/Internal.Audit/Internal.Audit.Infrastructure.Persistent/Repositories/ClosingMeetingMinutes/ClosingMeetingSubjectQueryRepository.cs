using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ClosingMeetingMinutes;

public class ClosingMeetingSubjectQueryRepository : QueryRepositoryBase<ClosingMeetingSubject>, IClosingMeetingSubjectQueryRepository
{
    public ClosingMeetingSubjectQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<ClosingMeetingSubject>> GetAllSubjectListByCMMId(Guid cmmId)
    {
        var query = @"select * from BranchAudit.ClosingMeetingSubjects where ClosingMeetingMinutesId =@cmmId";
        var parameters = new Dictionary<string, object> { { "cmmId", cmmId } };
        return await Get(query, parameters);
    }
}
