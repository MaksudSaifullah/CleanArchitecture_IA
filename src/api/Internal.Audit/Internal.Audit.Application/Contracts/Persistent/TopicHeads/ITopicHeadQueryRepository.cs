using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.TopicHeads;

public interface ITopicHeadQueryRepository : IAsyncQueryRepository<TopicHead>
{
    Task<(long, IEnumerable<TopicHead>)> GetAll(int pageSize, int pageNumber, string searchTerm);
    Task<TopicHead> GetById(Guid id);
}

