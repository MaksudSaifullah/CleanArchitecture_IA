using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Config;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedules;

public class AuditScheduleQueryrepository : QueryRepositoryBase<AuditSchedule>, IAuditScheduleQueryRepository
{
    public AuditScheduleQueryrepository(string _connectionString) : base(_connectionString)
    {
    }

    public Task<IEnumerable<AuditSchedule>> GetList(Guid? PlanId)
    {
        var query = @"
                 SELECT *
                FROM  [BranchAudit].[AuditSchedule] x
                inner join [BranchAudit].[AuditCreation] y
                on x.[AuditCreationId]=y.Id
                inner join [Config].[AuditType] l
                on l.Id=y.AuditTypeId
                inner JOIN [BranchAudit].[AuditScheduleParticipants] z 
                on z.[AuditScheduleId]=x.id
                inner JOIN [BranchAudit].[AuditScheduleBranch] p 
                on p.[AuditScheduleId]=x.id
                where y.id='4CB382C9-5512-ED11-B3B2-00155D610B18'";

        var parameters = new Dictionary<string, object> {};
        string splitters = "Id, Id, Id, Id, Id, Id";
        //var data = await Get<AuditSchedule, AuditCreation, AuditType, AuditPlan, AuditScheduleParticipants,User,>(query, () =>
        //{
        //    AmbsDataSync doc;
        //    doc = ambsdatasync;
        //    doc.DataRequestQueueService = datarequestqueueservice;
        //    doc.DataRequestQueueService.Country = country;
        //    doc.RiskCriteria = riskcriteria;
        //    doc.RiskCriteria.CommonValueRatingType = rating;
        //    doc.RiskCriteria.CommonValueRiskCriteriaType = criteria;
        //    //doc.RiskCriteria.CommonValueRatingType = commonvaluerating;
        //    //doc.RiskCriteria.CommonValueRiskCriteriaType = commonvaluecriteria;
        //    //doc.DataRequestQueueService.Country = country;
        //    //doc.RiskCriteria = riskcriteria;
        //    //doc.RiskCriteria.CommonValueRatingType = commonvaluetype;
        //    //doc.RiskCriteria.CommonValueRatingType = commonvaluecriteriatype;
        //    //doc.DocumentSource = documentsource;

        //    return doc;
        //}, parameters, splitters, false);
        //return data.Distinct();
        throw new NotImplementedException();    
    }
}
