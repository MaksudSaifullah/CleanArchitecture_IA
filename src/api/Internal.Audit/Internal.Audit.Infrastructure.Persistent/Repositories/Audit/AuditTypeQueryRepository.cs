using Internal.Audit.Application.Contracts.Persistent.Audit;
using Internal.Audit.Domain.Entities.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Audit
{
    public class AuditTypeQueryRepository: QueryRepositoryBase<AuditType>, IAuditTypeQueryRepository
    {
        public AuditTypeQueryRepository(string _connectionString) : base(_connectionString)
        {

        }

        public async Task<(long, IEnumerable<AuditType>)> GetAll(int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetAuditTypeListProcedure] @pageSize,@pageNumber";
            var parameters = new Dictionary<string, object> {  { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
            return await GetWithPagingInfo(query, parameters, false);
        }
    }
}
