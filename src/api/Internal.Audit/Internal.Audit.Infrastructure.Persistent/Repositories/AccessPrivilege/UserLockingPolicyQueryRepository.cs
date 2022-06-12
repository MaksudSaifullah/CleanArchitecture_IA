
using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AccessPrivilege;
public class UserLockingPolicyQueryRepository : QueryRepositoryBase<UserLockingPolicy>, IUserLockingPolicyQueryRepository
{
    public UserLockingPolicyQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<UserLockingPolicy> Get()
    {
        var query = @"SELECT TOP 1 [Id]
                      ,[IsLockedOnNoLoginActivity]
                      ,[NoLoginActivityDays]
                      ,[LockedOnFailedLoginAttempts]
                      ,[NumberOfFailedLoginAttempts]
                      ,[FailedLoginAttemptsDuration]
                      ,[FailedLoginLockedDuration]
                      ,[UnlockedOnByAdmin]
                      ,[UnlockedOnByAdminDuration] 
                    FROM [security].[UserLockingPolicy] WHERE [IsDeleted] = 0 ORDER BY [CreatedOn] DESC";
        return await Single(query);
    }
}