using Internal.Audit.Application.Contracts.Persistent.WeightScoreConfigurations;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.WeightScoreConfigurations;

    public class WeightScoreConfigurationQueryRepository : QueryRepositoryBase<WeightScore>, IWeightScoreConfigurationQueryRepository
    {
    public WeightScoreConfigurationQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<WeightScore>)> GetAll(int pageSize, int pageNumber, string searchTerm)
    {

        var query = "EXEC [dbo].[GetTopicHeadListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTerm } };
        return await GetWithPagingInfo(query, parameters, false);

    }
    public async Task<WeightScore> GetByCountryId(Guid countryId)
    {
        var query = @"SELECT * FROM [BranchAudit].[WeightScore] AS ws
                    JOIN [BranchAudit].[TopicHead] AS th ON th.Id = ws.TopicHeadId
                    JOIN [common].[Country] AS c ON c.Id = th.CountryId
                    WHERE  c.[Id] = @id AND ws.IsDeleted = 0  ";
        var parameters = new Dictionary<string, object> { { "id", countryId } };

        return await Single(query, parameters);
    }
}

