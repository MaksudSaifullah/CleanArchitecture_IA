using Internal.Audit.Application.Contracts.Persistent;
using Internal.Audit.Application.Contracts.Persistent.Audit;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Audit
{
    public class AuditQueryRepository : QueryRepositoryBase<CompositAudit>, IAuditQueryRepository
    {
        public AuditQueryRepository(string _connectionString) : base(_connectionString)
        {

        }

        public async Task<(long, IEnumerable<CompositAudit>)> GetAll(string searchTerm, int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetAuditListProcedure] @pageSize,@pageNumber,@searchTerm";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTerm } };
            return await GetWithPagingInfo(query, parameters, false);
        }

        public async Task<CompositAudit> GetById(Guid id)
        {
            var query = @"SELECT ac.[Id],[CountryId],ac.[AuditTypeId],ap.Id [AuditPlanId],[AuditId], [Year],[AuditName],                           [AuditPeriodFrom],[AuditPeriodTo] 
                        FROM[BranchAudit].[AuditCreation] ac
                        INNER JOIN[BranchAudit].AuditPlan ap on ac.AuditPlanId = ap.Id
                        INNER JOIN[BranchAudit].RiskAssessment ra on ap.RiskAssessmentId = ra.Id WHERE ac.Id = @id AND ac.[IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }
    }
}
