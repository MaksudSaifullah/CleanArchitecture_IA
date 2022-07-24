using Internal.Audit.Application.Contracts.Persistent.Designations;
using Internal.Audit.Domain.Entities.common;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Designations;
public class DesignationQueryRepository : QueryRepositoryBase<Designation>, IDesignationQueryRepository
{
    public DesignationQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<Designation>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
    {
        string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
        if(!string.IsNullOrWhiteSpace(searchTermConverted))
        {
            searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
        }
        var query = "EXEC [dbo].[GetDesignationListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };
        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<IEnumerable<Designation>> GetAll()
    {
        var query = "SELECT [Id],[Name],[Description],[IsActive] FROM [common].[Designation] WHERE [IsDeleted] = 0";
        return await Get(query);
    }
    public async Task<Designation> GetById(Guid id)
    {
        var query = "SELECT [Id],[Name],[Description],[IsActive] FROM [common].[Designation] WHERE Id = @id AND [IsDeleted] = 0";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }
}
