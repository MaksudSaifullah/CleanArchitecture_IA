
using Internal.Audit.Application.Contracts.Persistent.AccessPrivilege;
using Internal.Audit.Domain.Entities.security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AccessPrivilege;
public class PasswordPolicyQueryRepository : QueryRepositoryBase<PasswordPolicy>, IPasswordPolicyQueryRepository
{
    public PasswordPolicyQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<PasswordPolicy> Get()
    {
        var query = @"SELECT TOP 1 [Id]
                    ,[MinLength]
                    ,[MaxLength]
                    ,[IsAlphabetMandatory]
                    ,[AlphabetLength]
                    ,[IsNumberMandatory]
                    ,[NumericLength]
                    ,[IsSpecialCharsMandatory]
                    ,[SpecialCharsLength]
                    ,[IsPasswordChangeForcedOnFirstLogin]
                    ,[IsPasswordResetForcedPeriodically]
                    ,[ForcePasswordResetDays]
                    ,[NotifyPasswordResetDays]
                    FROM [security].[PasswordPolicy] WHERE [IsDeleted] = 0 ORDER BY [CreatedOn] DESC";
        return await Single(query);
    }
}