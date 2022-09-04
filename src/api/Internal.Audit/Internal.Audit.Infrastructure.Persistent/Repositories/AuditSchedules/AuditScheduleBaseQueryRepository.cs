using Internal.Audit.Application.Contracts.Persistent.AuditSchedules;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Security;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.AuditSchedules;

public class AuditScheduleBaseQueryRepository : QueryRepositoryBase<AuditSchedule>, IAuditScheduleBaseQueryRepository
{
    public AuditScheduleBaseQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<IEnumerable<AuditSchedule>> GetAuditScheduleByCreationId(Guid? Id)
    {
        var query = @"select sch.Id,sch.AuditCreationId,sch.ScheduleStartDate,sch.ScheduleEndDate,sch.ScheduleId,sch.ScheduleState,sch.ExecutionState,cra.Id,cra.AuditPlanId,cra.AuditId,cra.Year,cra.AuditName,cra.AuditTypeId,
cra.AuditPeriodFrom,cra.AuditPeriodTo,auType.Name as AuditTypeName,participants.*,usr.*,emp.*,asBranch.*,branch.BranchName

from BranchAudit.AuditSchedule sch
inner join BranchAudit.AuditCreation cra
on sch.AuditCreationId=cra.Id
inner join BranchAudit.AuditPlan auPlan
on cra.AuditPlanId =auPlan.Id
inner JOIN Config.AuditType auType
on auType.Id=cra.AuditTypeId
inner JOIN BranchAudit.AuditScheduleParticipants participants
on participants.AuditScheduleId=sch.Id
INNER JOIN security.[User] usr
on participants.UserId=usr.Id
INNER JOIN security.Employee emp
on usr.Id=emp.UserId
inner JOIN BranchAudit.AuditScheduleBranch asBranch
on asBranch.AuditScheduleId=sch.Id
INNER JOIN security.Branch branch
on asBranch.BranchId=branch.Id
                    where sch.AuditCreationId=@auditcreationid and sch.[IsDeleted]=0";

        string splitters = "Id, Id, Id, Id, Id";
        var parameters = new Dictionary<string, object> { { "auditcreationid", Id } };

        var auditScheduleDic = new Dictionary<Guid, AuditSchedule>();
        var participantsDic = new Dictionary<Guid, AuditScheduleParticipants>();
        var userDic = new Dictionary<Guid, User>();
        var branchDic = new Dictionary<Guid, AuditScheduleBranch>();


        var data = await Get<AuditSchedule, AuditCreation, AuditScheduleParticipants, User, Employee, AuditScheduleBranch, AuditSchedule>(query, (auditschedule, auditcreation, auditscheduleparticipants, user, employee, auditbranch) =>
        {
            AuditSchedule u;
            if (!auditScheduleDic.ContainsKey(auditschedule.Id))
            {
                auditScheduleDic.Add(auditschedule.Id, auditschedule);
                u = auditschedule;
                u.AuditScheduleParticipants = new List<AuditScheduleParticipants>();
                u.AuditScheduleBranch = new List<AuditScheduleBranch>();
            }
            else
            {
                u = auditScheduleDic[auditschedule.Id];
            }
            u.AuditCreation = auditcreation;
            // u.AuditCreation.AuditPlan=auditplan;
            if (!participantsDic.ContainsKey(auditscheduleparticipants.Id))
            {
                auditscheduleparticipants.User = user;
                auditscheduleparticipants.User.Employee = employee;
                participantsDic.Add(auditscheduleparticipants.Id, auditscheduleparticipants);
                u.AuditScheduleParticipants.Add(auditscheduleparticipants);
            }
            //if (!userDic.ContainsKey(user.Id))
            //{
            //    userDic.Add(user.Id, user);
            //    u.AuditScheduleParticipants.
            //}
            if (!branchDic.ContainsKey(auditbranch.Id))
            {
                branchDic.Add(auditbranch.Id, auditbranch);
                u.AuditScheduleBranch.Add(auditbranch);
            }
            return u;
        }, parameters, splitters, false);
        var final = data.Distinct();
        return final;
    }

    public async Task<IEnumerable<AuditSchedule>> GetAuditScheduleById(Guid? Id)
    {
        var query = @"select sch.Id,sch.AuditCreationId,sch.ScheduleStartDate,sch.ScheduleEndDate,sch.ScheduleId,sch.ScheduleState,sch.ExecutionState,cra.Id,cra.AuditPlanId,cra.AuditId,cra.Year,cra.AuditName,cra.AuditTypeId,
cra.AuditPeriodFrom,cra.AuditPeriodTo,auType.Name as AuditTypeName,participants.*,usr.*,emp.*,asBranch.*,branch.BranchName

from BranchAudit.AuditSchedule sch
inner join BranchAudit.AuditCreation cra
on sch.AuditCreationId=cra.Id
inner join BranchAudit.AuditPlan auPlan
on cra.AuditPlanId =auPlan.Id
inner JOIN Config.AuditType auType
on auType.Id=cra.AuditTypeId
inner JOIN BranchAudit.AuditScheduleParticipants participants
on participants.AuditScheduleId=sch.Id
INNER JOIN security.[User] usr
on participants.UserId=usr.Id
INNER JOIN security.Employee emp
on usr.Id=emp.UserId
inner JOIN BranchAudit.AuditScheduleBranch asBranch
on asBranch.AuditScheduleId=sch.Id
INNER JOIN security.Branch branch
on asBranch.BranchId=branch.Id
                    where sch.Id=@auditscheduleid and sch.[IsDeleted]=0";

        string splitters = "Id, Id, Id, Id, Id";
        var parameters = new Dictionary<string, object> { { "auditscheduleid", Id } };

        var auditScheduleDic = new Dictionary<Guid, AuditSchedule>();
        var participantsDic = new Dictionary<Guid, AuditScheduleParticipants>();
        var userDic = new Dictionary<Guid, User>();
        var branchDic = new Dictionary<Guid, AuditScheduleBranch>();


        var data = await Get<AuditSchedule, AuditCreation, AuditScheduleParticipants, User, Employee, AuditScheduleBranch, AuditSchedule>(query, (auditschedule, auditcreation, auditscheduleparticipants, user, employee, auditbranch) =>
       {
           AuditSchedule u;
           if (!auditScheduleDic.ContainsKey(auditschedule.Id))
           {
               auditScheduleDic.Add(auditschedule.Id, auditschedule);
               u = auditschedule;
               u.AuditScheduleParticipants = new List<AuditScheduleParticipants>();
               u.AuditScheduleBranch = new List<AuditScheduleBranch>();
           }
           else
           {
               u = auditScheduleDic[auditschedule.Id];
           }
           u.AuditCreation = auditcreation;
            // u.AuditCreation.AuditPlan=auditplan;
            if (!participantsDic.ContainsKey(auditscheduleparticipants.Id))
           {
               auditscheduleparticipants.User = user;
               auditscheduleparticipants.User.Employee = employee;
               participantsDic.Add(auditscheduleparticipants.Id, auditscheduleparticipants);
               u.AuditScheduleParticipants.Add(auditscheduleparticipants);
           }
            //if (!userDic.ContainsKey(user.Id))
            //{
            //    userDic.Add(user.Id, user);
            //    u.AuditScheduleParticipants.
            //}
            if (!branchDic.ContainsKey(auditbranch.Id))
           {
               branchDic.Add(auditbranch.Id, auditbranch);
               u.AuditScheduleBranch.Add(auditbranch);
           }
           return u;
       }, parameters, splitters, false);
        var final = data.Distinct();
        return final;

    }
}
