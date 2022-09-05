using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ClosingMeetingMinutes;

public class ClosingMeetingMinutesBaseQueryRepository : QueryRepositoryBase<ClosingMeetingMinute>, IClosingMeetingMinutesBaseQueryRepository
{
    public ClosingMeetingMinutesBaseQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<ClosingMeetingMinute> GetById(Guid id)
    {
        var query = @"
SELECT *

  FROM [BranchAudit].[ClosingMeetingMinutes] cmm
  Inner Join [BranchAudit].[ClosingMeetingPresents] cmp on cmp.ClosingMeetingMinutesId = cmm.Id
  Inner Join [BranchAudit].[ClosingMeetingApologies] cma on cma.ClosingMeetingMinutesId = cmm.Id
  Inner Join [BranchAudit].[ClosingMeetingSubjects] cms on cms.ClosingMeetingMinutesId = cmm.Id
 -- INNER JOIN [security].[User] usr on usr.Id = cmm.AgreedByUserId
--   INNER JOIN [security].[User] usrp on usrp.Id = cmm.PreparedByUserId
 -- INNER JOIN [security].[Branch] brnch on brnch.Id = cmm.AuditScheduleBranchId
  Where cmm.[Id] =  @id  AND cmm.IsDeleted = 0";
        var parameters = new Dictionary<string, object> { { "id", id } };
        string splitters = "Id, Id, Id";
        var closingMeetingDictionary = new Dictionary<Guid, ClosingMeetingMinute>();
        var presentDictionary = new Dictionary<Guid, ClosingMeetingPresent>();
        var apologyDictionary = new Dictionary<Guid, ClosingMeetingApology>();
        var subjectsDictionary = new Dictionary<Guid, ClosingMeetingSubject>();


        var result = await Get<ClosingMeetingMinute, ClosingMeetingPresent, ClosingMeetingApology, ClosingMeetingSubject,  ClosingMeetingMinute>(query, (closingmeetingminutes, present, apology, subject) =>
         {
             ClosingMeetingMinute cm;
             if (!closingMeetingDictionary.ContainsKey(closingmeetingminutes.Id))
             {
                 closingMeetingDictionary.Add(closingmeetingminutes.Id, closingmeetingminutes);
                 cm = closingmeetingminutes;
                 cm.UserPresents = new List<ClosingMeetingPresent>();
                 cm.UserApologies = new List<ClosingMeetingApology>();
                 cm.MeetingMinutesSubjects = new List<ClosingMeetingSubject>();
             }
             else
             {
                 cm = closingMeetingDictionary[closingmeetingminutes.Id];
             }

             if (!presentDictionary.ContainsKey(present.Id))
             {
                 presentDictionary.Add(present.Id, present);
                 cm.UserPresents.Add(present);
             }
             if (!apologyDictionary.ContainsKey(apology.Id))
             {
                 apologyDictionary.Add(apology.Id, apology);
                 cm.UserApologies.Add(apology);
             }
             if (!subjectsDictionary.ContainsKey(subject.Id))
             {
                 subjectsDictionary.Add(subject.Id, subject);
                 cm.MeetingMinutesSubjects.Add(subject);
             }

             return cm;

         }, parameters, splitters, false);
        return result.Distinct().FirstOrDefault();
    }
}
