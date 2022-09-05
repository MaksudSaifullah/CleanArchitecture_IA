using Internal.Audit.Application.Contracts.Persistent.ClosingMeetingMinutes;
using Internal.Audit.Domain.CompositeEntities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.ClosingMeetingMinutes;

public class ClosingMeetingMinuteQueryRepository : QueryRepositoryBase<CompositeClosingMeetingMinute>, IClosingMeetingMinutesQueryRepository
{
	public ClosingMeetingMinuteQueryRepository(string _connectionString) : base(_connectionString)
	{
	}

	public async Task<(long, IEnumerable<CompositeClosingMeetingMinute>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
	{
		string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
		if (!string.IsNullOrWhiteSpace(searchTermConverted))
		{
			searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
		}
		var query = "EXEC [dbo].[GetClosingMeetingMinutesListProcedure] @pageSize,@pageNumber,@searchTerm";
		var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };
		return await GetWithPagingInfo(query, parameters, false);
	}

    public async Task<CompositeClosingMeetingMinute> GetById(Guid id)
    {
        var query = @"SELECT cmm.[Id]
      ,cmm.[MeetingMinutesCode]
      ,cmm.[AuditScheduleId]
      ,cmm.[MeetingMinutesDate]
      ,cmm.[MeetingMinutesName]
      ,cmm.[AuditOn]
      ,cmm.[MeetingHeld]
      ,cmm.[AuditScheduleBranchId]
      ,cmm.[IsDeleted]
      ,cmm.[AgreedByUserId]
      ,cmm.[PreparedByUserId]
	  ,(SELECT
	STUFF((SELECT ', ' + CAST(usr.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[ClosingMeetingApologies] cma
	INNER JOIN [security].[User] usr on cma.UserId= usr.Id
	WHERE cma.UserId= usr.Id
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) as ClosingMeetingApologies
	,(SELECT
	STUFF((SELECT ', ' + CAST(usr.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[ClosingMeetingPresents] cmp
	INNER JOIN [security].[User] usr on cmp.UserId= usr.Id
	WHERE cmp.UserId= usr.Id
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) as ClosingMeetingPresents
	,(SELECT
	STUFF((SELECT ', ' + CAST(usr.UserName AS nVARCHAR(max)) 
	FROM [BranchAudit].[ClosingMeetingSubjects] cms
	INNER JOIN [security].[User] usr on cms.UserId= usr.Id
	WHERE cms.UserId= usr.Id
	FOR XML PATH(''), TYPE)
	.value('.','NVARCHAR(MAX)'),1,2,' ')) as ClosingMeetingSubjects

  FROM [BranchAudit].[ClosingMeetingMinutes] cmm
 -- Inner Join [BranchAudit].[ClosingMeetingPresents] cmp on cmp.ClosingMeetingMinutesId = cmm.Id
 -- Inner Join [BranchAudit].[ClosingMeetingApologies] cma on cma.ClosingMeetingMinutesId = cmm.Id
 -- Inner Join [BranchAudit].[ClosingMeetingSubjects] cms on cms.ClosingMeetingMinutesId = cmm.Id
  INNER JOIN [security].[User] usr on usr.Id = cmm.AgreedByUserId
   INNER JOIN [security].[User] usrp on usrp.Id = cmm.PreparedByUserId
  INNER JOIN [security].[Branch] brnch on brnch.Id = cmm.AuditScheduleBranchId
  Where cmm.[Id] =  @id  AND cmm.IsDeleted = 0 ";
        var parameters = new Dictionary<string, object> { { "id", id } };

        return await Single(query, parameters);
    }
}


