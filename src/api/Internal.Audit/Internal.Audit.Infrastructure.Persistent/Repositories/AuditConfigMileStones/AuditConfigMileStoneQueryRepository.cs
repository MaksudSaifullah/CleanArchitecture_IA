using Internal.Audit.Application.Contracts.Persistent.AuditConfigMilestones;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Config;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditConfigMileStones;

public class AuditConfigMileStoneQueryRepository : QueryRepositoryBase<AuditConfigMileStone>, IAuditConfigMilestoneQueryReposiotry
{
    public AuditConfigMileStoneQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<AuditConfigMileStone>> GetByAuditScheduleId(Guid id)
    {
        var query = @"select @id as AuditScheduleId,x.Value as CommonValueAuditConfigMilestoneId, ISNULL(y.SetDate,null)as Setdate,x.* from(SELECT *
                    FROM [Config].[CommonValueAndType] 
                    where Type='AUDITCONFIGMILESTONE'
                    and IsActive=1
                    and IsDeleted=0
                    )x
                    left JOIN (  
                    SELECT *
                    FROM [BranchAudit].[AuditConfigMileStone]
                    where AuditScheduleId= @id
                    )y
                    on x.Value=y.CommonValueAuditConfigMilestoneId
                    ORDER by x.Value";
        string splitters = "Id";
        var parameters = new Dictionary<string, object> { {"id",id } };
        var data = await Get<AuditConfigMileStone, CommonValueAndType, AuditConfigMileStone>(query, (milestone, commonvalue) =>
        {
            AuditConfigMileStone acm;
            acm = milestone;
            acm.CommonValue = commonvalue;
            return acm;
        }, parameters, splitters, false);
        return data.Distinct();
    }
}
