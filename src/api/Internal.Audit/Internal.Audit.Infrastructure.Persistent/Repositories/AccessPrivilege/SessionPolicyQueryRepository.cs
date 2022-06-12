using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AccessPrivilege;
public class SessionPolicyQueryRepository : QueryRepositoryBase<SessionPolicy>, ISessionPolicyQueryRepository
{
    public SessionPolicyQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<SessionPolicy> Get()
    {
        var query = @"SELECT TOP 1 [Id]
                      ,[IsEnabled]
                      ,[Duration]
                      FROM [security].[SessionPolicy] WHERE [IsDeleted] = 0 ORDER BY [CreatedOn] DESC";
        return await Single(query);
    }
}



