using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Contracts.Persistent.RiskAssessments
{
    public interface IRiskAssessmentQueryRepository : IAsyncQueryRepository<CompositeRiskAssessment>
    {
        Task<(long, IEnumerable<CompositeRiskAssessment>)> GetAll(int pageSize, int pageNumber, string search, string year);

        Task<CompositeRiskAssessment> GetById(Guid id);
    }
}
