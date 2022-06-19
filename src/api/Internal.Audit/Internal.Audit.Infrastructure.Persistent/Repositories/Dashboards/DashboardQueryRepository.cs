using Internal.Audit.Application.Contracts.Persistent.Dashboards;
using Internal.Audit.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Dashboards
{
    public class DashboardQueryRepository : QueryRepositoryBase<DashBoardBase>, IDashboardQueryRepository
    {
        public DashboardQueryRepository(string _connectionString) : base(_connectionString)
        {
        }
        public async Task<IEnumerable<DashBoardBase>> GetAll()
        {
            var query = @"SELECT [Id]
                                ,[Name]
                                ,[Status]
                                ,[CreatedBy]
                                ,[CreatedOn]
                                FROM [common].[DashBoardBase]
                                WHERE [IsDeleted] = 0";
            return await Get(query);
        }
        public async Task<DashBoardBase> GetById(Guid id)
        {
            var query = @"SELECT [Id]
                                ,[Name]
                                ,[Status]
                                ,[CreatedBy]
                                ,[CreatedOn]
                                FROM [common].[DashBoardBase]
                                WHERE Id = @id AND [IsDeleted] = 0";
            var parameters = new Dictionary<string, object> { { "id", id } };

            return await Single(query, parameters);
        }

    }
}
