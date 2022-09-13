using Internal.Audit.Application.Contracts.Persistent.Checklists;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Checklists;

public class ChecklistTopicQueryRepository : QueryRepositoryBase<ChecklistTopic>, IChecklistTopicQueryRepository
{
    public ChecklistTopicQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<ChecklistTopic>> GetAllChecklistTopicByChecklistId(Guid checklistId)
    {
        var query = @"select * from BranchAudit.ChecklistTopics where ChecklistId =@checklistId";
        var parameters = new Dictionary<string, object> { { "checklistId", checklistId } };
        return await Get(query, parameters);
    }
}
