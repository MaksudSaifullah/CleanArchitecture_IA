using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedules;

public class AuditScheduleQueryrepository : QueryRepositoryBase<CompositAuditSchedule>, IAuditScheduleQueryRepository
{
    public AuditScheduleQueryrepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<(long, IEnumerable<CompositAuditSchedule>)> GetAll(string searchTerm, int pageSize, int pageNumber)
    {
        var query = "EXEC [dbo].[GetAuditScheduleListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTerm } };
        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<CompositAuditSchedule> GetById(Guid id)
    {
        var query = @"SELECT distinct  a.Id,c.Id CountryId ,c.Name Country,a.ScheduleId,a.ScheduleState,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.UserId=y.Id and x.CommonValueParticipantId=1
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) Approver,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.UserId=y.Id and x.CommonValueParticipantId=2
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) TeamLeader,
(SELECT
	STUFF((SELECT ', ' + CAST(y.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[AuditScheduleParticipants] x
	INNER JOIN [security].[User]  y on x.UserId=y.Id
	WHERE x.UserId=y.Id and x.CommonValueParticipantId=3
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) Auditor,
	a.ScheduleStartDate,
	a.ScheduleEndDate,
a.CreatedOn
FROM [BranchAudit].AuditSchedule a
INNER JOIN [BranchAudit].[AuditCreation] ac on a.AuditCreationId=ac.Id
INNER JOIN [BranchAudit].[AuditPlan] ap on ac.AuditPlanId=ap.Id
INNER JOIN [BranchAudit].[RiskAssessment] ra on ap.RiskAssessmentId=ra.Id
INNER JOIN [common].[Country] c on ra.CountryId=c.Id
INNER JOIN [BranchAudit].[AuditScheduleParticipants] asp on a.Id=asp.AuditScheduleId
INNER JOIN [security].[User] u on asp.UserId=u.Id
Where a.[Id] =  @id AND a.IsDeleted = 0 
 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }
}
