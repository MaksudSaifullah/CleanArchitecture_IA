using Internal.Audit.Application.Contracts.Persistent.AuditScheduleConfigurationsOwner;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.security;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditScheduleConfigurationsOwner;

public class AuditScheduleConfigurationOwnerQueryRepository : QueryRepositoryBase<AuditScheduleConfigurationOwner>, IAuditScheduleConfigurationOwnerQueryRepository
{
    public AuditScheduleConfigurationOwnerQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<AuditScheduleConfigurationOwner> GetAllAsync(Guid? AuditScheduleId, int TypeId)
    {
        var query = @"SELECT *     
                    FROM [BranchAudit].[AuditScheduleConfigurationOwner] x
                    INNER JOIN security.[User] y
                    on x.UserId=y.Id
                    inner JOIN security.Branch b
                    on b.Id=x.BranchId
                    where x.AuditScheduleId=@auditscheduleid
                    and x.CommonValueAuditScheduleRiskOwnerTypetId=@typeid";
        var parameters = new Dictionary<string, object> { { "auditscheduleid", AuditScheduleId }, { "typeid", TypeId } };
        string splitters = "Id,Id";
        var auditScheduleConfigurationOwnerDictionary = new Dictionary<Guid, AuditScheduleConfigurationOwner>();
        var userDictionary = new Dictionary<Guid, User>();
        var data = await Get<AuditScheduleConfigurationOwner, User, Branch, AuditScheduleConfigurationOwner>(query, (configurationowner, user, branch) =>
        {
            AuditScheduleConfigurationOwner uc;
            if (!auditScheduleConfigurationOwnerDictionary.ContainsKey(configurationowner.AuditScheduleId))
            {
                auditScheduleConfigurationOwnerDictionary.Add(configurationowner.AuditScheduleId, configurationowner);
                uc = configurationowner;
                uc.User=new List<User>();    
                
            }
            else
            {
                uc = auditScheduleConfigurationOwnerDictionary[configurationowner.AuditScheduleId];
            }
            if (!userDictionary.ContainsKey(user.Id))
            {
                userDictionary.Add(user.Id, user);
                uc.User.Add(user);
            }
            uc.Branch=branch;
            return uc;
        }, parameters, splitters, false);
        return data.FirstOrDefault();
    }
}
