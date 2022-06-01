using Internal.Audit.Application.Contracts.Persistent.Countries;
using Internal.Audit.Domain.Entities.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Designations;
public class DesignationQueryRepository : QueryRepositoryBase<Designation>, IDesignationQueryRepository
{
    public DesignationQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<IEnumerable<Designation>> GetAll()
    {
        var query = "SELECT [Id],[Name],[Description],[IsActive] FROM [common].[Designation] WHERE [IsActive] = 1";
        return await Get(query);
    }
    public async Task<Designation> GetById(Guid id)
    {
        var query = "SELECT [Id],[Name],[Description],[IsActive] FROM [common].[Designation] WHERE Id = @id AND [IsActive] = 1";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }
}
