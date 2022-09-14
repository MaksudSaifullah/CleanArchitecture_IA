using Internal.Audit.Application.Contracts.Persistent.Checklists;
using Internal.Audit.Domain.Entities.BranchAudit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Checklists;

public class ChecklistBaseQueryRepository : QueryRepositoryBase<Checklist>, IChecklistBaseQueryRepository
{
    public ChecklistBaseQueryRepository(string _connectionString) : base(_connectionString)
    {
    }

    public async Task<Checklist> GetById(Guid id)
    {
        var query = @"
SELECT *

  FROM [BranchAudit].[Checklists] cl
  Inner Join [BranchAudit].[ChecklistTopics] clt on clt.ChecklistId = cl.Id
  Inner Join [BranchAudit].[ChecklistTopicDetails] cltd on cltd.ChecklistTopicId = clt.Id

  Where cl.[Id] =  @id  AND cl.IsDeleted = 0";
        var parameters = new Dictionary<string, object> { { "id", id } };
        string splitters = "Id, Id";
        var checklistDictionary = new Dictionary<Guid, Checklist>();
        var topicDictionary = new Dictionary<Guid, ChecklistTopic>();
        var topicDetailDictionary = new Dictionary<Guid, ChecklistTopicDetail>();


        var result = await Get<Checklist, ChecklistTopic, ChecklistTopicDetail, Checklist>(query, (checklist, checklisttopic, checklisttopicDetail) =>
        {
            Checklist cm;
        if (!checklistDictionary.ContainsKey(checklist.Id))
            {
                checklistDictionary.Add(checklist.Id, checklist);
                cm = checklist;
                cm.ChecklistTopicHeads = new List<ChecklistTopic>();
                //cm.ChecklistTopic. = new List<ChecklistTopicDetail>();
            }
            else
            {
                cm = checklistDictionary[checklist.Id];
            }

            if (!topicDictionary.ContainsKey(checklisttopic.Id))
            {
                topicDictionary.Add(checklisttopic.Id, checklisttopic);
                cm.ChecklistTopicHeads.Add(checklisttopic);
                cm.ChecklistTopicHeads.FirstOrDefault().ChecklistTopicHeadDetails = new List<ChecklistTopicDetail>();
                cm.ChecklistTopicHeads.FirstOrDefault().ChecklistTopicHeadDetails.Add(checklisttopicDetail);
            }

            //if (!topicDetailDictionary.ContainsKey(checklisttopic.Id))
            //{
            //    topicDetailDictionary.Add(checklisttopicDetail.Id, checklisttopicDetail);
            //    cm..Add(checklisttopicDetail);
            //}


            return cm;

        }, parameters, splitters, false);
        return result.Distinct().FirstOrDefault();
    }
}
