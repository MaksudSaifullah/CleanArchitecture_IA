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
            var query = "SELECT [Id],[CountryId],[AuditTypeId],[PlanId],[AuditId], [Year],[AuditName],[AuditPeriodFrom],[AuditPeriodTo] FROM [BranchAudit].[AuditCreation] WHERE Id = @id AND [IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }
    }
}
