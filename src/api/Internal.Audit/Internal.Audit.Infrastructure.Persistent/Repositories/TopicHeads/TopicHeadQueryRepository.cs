using Internal.Audit.Application.Contracts.Persistent.TopicHeads;
using Internal.Audit.Domain.Entities.BranchAudit;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.TopicHeads;
public class TopicHeadQueryRepository : QueryRepositoryBase<TopicHead>, ITopicHeadQueryRepository
{
    public TopicHeadQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<(long, IEnumerable<TopicHead>)> GetAll(int pageSize, int pageNumber, string searchTerm)
    {

        var query = "EXEC [dbo].[GetTopicHeadListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTerm } };
        return await GetWithPagingInfo(query, parameters, false);

    }
    public async Task<TopicHead> GetById(Guid id)
    {
        var query = "SELECT [Id],[CountryId],[Name],[EffectiveFrom],[EffectiveTo],[Description] FROM [BranchAudit].[TopicHead] WHERE Id = @id AND [IsDeleted] = 0";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }
    public async Task<IEnumerable<TopicHead>> GetByFilter(string FilterName, Guid FilterValue)
    {
        var query = "SELECT [Id],[CountryId],[Name],[EffectiveFrom],[EffectiveTo],[Description] FROM [BranchAudit].[TopicHead] WHERE "+ FilterName + " = @FilterValue AND [IsDeleted] = 0";
        var parameters = new Dictionary<string, object> { { "FilterValue", FilterValue } };

        return await Get(query, parameters);
    }

    public async Task<IEnumerable<TopicHead>> GetByCountryIdAnddateRange(Guid? CountryId, DateTime? FromDate, DateTime? ToDate)
    {
        var query = "SELECT [Id],[CountryId],[Name],[EffectiveFrom],[EffectiveTo],[Description] FROM [BranchAudit].[TopicHead] WHERE countryId = @CountryId AND [IsDeleted] = 0 and CAST(EffectiveFrom as DATE)>=CAST(@FromDate as date) and CAST(EffectiveTo as DATE)<=CAST(@ToDate as date) ";
        var parameters = new Dictionary<string, object> { { "CountryId", CountryId }, { "FromDate", FromDate }, { "ToDate", ToDate } };

        return await Get(query, parameters);
    }
}
