using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedules;

public class AuditScheduleQueryrepository : QueryRepositoryBase<CompositAuditSchedule>, IAuditScheduleQueryRepository
{
    public AuditScheduleQueryrepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositAuditSchedule>)> GetAll(string searchTerm, int pageSize, int pageNumber)
    {
        var query = "EXEC [dbo].[GetAuditScheduleListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTerm } };
        return await GetWithPagingInfo(query, parameters, false);
    }
}
