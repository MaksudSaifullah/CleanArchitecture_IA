using Internal.Audit.Application.Contracts.Persistent.Checklists;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Checklists;

public class ChecklistTopicDetailQueryRepository : QueryRepositoryBase<ChecklistTopicDetail>, IChecklistTopicDetailQueryRepository
{
    public ChecklistTopicDetailQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<ChecklistTopicDetail>> GetAllChecklistTopicDetailByChecklistTopicId(Guid checklistTopicId)
    {
        var query = @"select * from BranchAudit.ChecklistTopicDetails where ChecklistTopicId =@checklistTopicId";
        var parameters = new Dictionary<string, object> { { "checklistTopicId", checklistTopicId } };
        return await Get(query, parameters);
    }
}
