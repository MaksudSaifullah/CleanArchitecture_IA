using Internal.Audit.Application.Contracts.Persistent.EmailConfigs;
using Internal.Audit.Domain.CompositeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.EmailConfig
{
    public class EmailTypeQueryRepository : QueryRepositoryBase<EmailType>, IEmailTypeQueryRepository
    {
        public EmailTypeQueryRepository(string _connectionString) : base(_connectionString)
        {

        }
        public async Task<(long, IEnumerable<EmailType>)> GetAll(int pageSize, int pageNumber)
        {
            var query = "EXEC [dbo].[GetEmailTypeListProcedure] @pageSize,@pageNumber";
            var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber } };
            return await GetWithPagingInfo(query, parameters, false);
        }
    }
}
