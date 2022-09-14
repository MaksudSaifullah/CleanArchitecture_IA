using Internal.Audit.Application.Contracts.Persistent.Issues;
using Internal.Audit.Domain.Entities.BranchAudit;
using Internal.Audit.Domain.Entities.Config;

namespace Internal.Audit.Infrastructure.Persistent.Repositories.Issues;
public class IssueQueryRepository : QueryRepositoryBase<Issue>, IIssueQueryRepository
{
    public IssueQueryRepository(string _connectionString) : base(_connectionString)
    {
    }
    public async Task<(long, IEnumerable<Issue>)> GetAll(int pageSize, int pageNumber, dynamic searchTerm = null)
    {
        string searchTermConverted = (object)searchTerm == null ? null : Convert.ToString(searchTerm);
        if (!string.IsNullOrWhiteSpace(searchTermConverted))
        {
            searchTermConverted = searchTermConverted.Replace("{", "").Replace("}", "");
        }
        var query = "EXEC [dbo].[GetIssueListProcedure] @pageSize,@pageNumber,@searchTerm";
        var parameters = new Dictionary<string, object> { { "@pageSize", pageSize }, { "@pageNumber", pageNumber }, { "@searchTerm", searchTermConverted } };

        return await GetWithPagingInfo(query, parameters, false);
    }
    public async Task<Issue> GetById(Guid id)
    {
       // var query =
       //     @"SELECT 
	      //                  issue.[Id]
							//,issue.Code
							//,issue.IssueTitle
							//,issue.Policy
							//,issue.TargetDate
							//,issue.Details
							//,issue.RootCause
							//,issue.BusinessImpact
							//,issue.PotentialRisk
							//,issue.AuditorRecommendation
							//,issue.Remarks
							//,issue.[CreatedBy]
							//,issue.[CreatedOn]		                    
							//,cvtLikelihood.Text AS LikelihoodType
							//,cvtImpact.Text AS ImpactType
							//,cvtRiskRating.Text AS RatingType
							//,cvtStatus.Text AS StatusType    
							//--,STRING_AGG(employee.Name , ', ') AS IssueOwner
							//,STUFF((SELECT ', ' + employee.Name
							//		 FROM [config].[IssueOwner] as issueOwner
							//		 INNER JOIN  [security].[Employee] as employee on employee.Id = issueOwner.[OwnerId]
							//		 WHERE  issueOwner.[IssueId] = issue.[Id]
							//		 FOR XML PATH(''),TYPE)
							//		 .value('.','NVARCHAR(MAX)'),1,2,'') AS IssueOwners
							
       //                  FROM [BranchAudit].[Issue] as issue
	      //                  INNER JOIN [config].[CommonValueAndType] as cvtLikelihood on cvtLikelihood.Id = issue.LikelihoodTypeId
       //                     INNER JOIN [config].[CommonValueAndType] as cvtImpact on cvtImpact.Id = issue.ImpactTypeId
       //                     INNER JOIN [config].[CommonValueAndType] as cvtRiskRating on cvtRiskRating.Id = issue.RatingTypeId
							//INNER JOIN [config].[CommonValueAndType] as cvtStatus on cvtStatus.Id = issue.StatusTypeId
							
       //                  WHERE issue.[IsDeleted] = 0 and issue.[Id] = @id
       //                  ORDER BY issue.[CreatedOn] DESC";
        var query = @"select 
                    Issue.*,cvtStatus.Text as StatusType,cvtRating.Text as RatingType, 
                            AuditSchedule.ScheduleId as AuditScheduleCode,
                            STUFF((SELECT ', ' + employee.Name
							FROM [config].[IssueOwner] as issueOwner
							INNER JOIN [security].[User] as usr on usr.id = issueOwner.OwnerId
							INNER JOIN  [security].[Employee] as employee on employee.UserId = usr.id
							WHERE  issueOwner.[IssueId] = issue.[Id]
							FOR XML PATH(''),TYPE)
							.value('.','NVARCHAR(MAX)'),1,2,'') AS IssueOwners,

                            STUFF((SELECT ',   ' + Branch.BranchName
						    FROM BranchAudit.IssueBranch
						    INNER JOIN security.Branch on Branch.Id = IssueBranch.BranchId									 
						    WHERE  IssueBranch.[IssueId] = issue.[Id]
						    FOR XML PATH(''),TYPE)
						    .value('.','NVARCHAR(MAX)'),1,2,'') AS Branches,

                    IssueActionPlan.*,  STUFF((SELECT ', ' + employee.Name
							FROM BranchAudit.IssueActionPlanOwner
							INNER JOIN [security].[User] as usr on usr.id = IssueActionPlanOwner.OwnerId
							INNER JOIN  [security].[Employee] as employee on employee.UserId = usr.id
							WHERE IssueActionPlanOwner.IssueActionPlanId = IssueActionPlan.Id
							FOR XML PATH(''),TYPE)
							.value('.','NVARCHAR(MAX)'),1,2,'') AS IssueActionPlanOwners,
                    IssueActionPlanOwner.*, 
                    IssueBranch.*, 
                    IssueOwner.*
                        from BranchAudit.Issue 
                        left join BranchAudit.IssueActionPlan on IssueActionPlan.IssueId = Issue.Id
                        left join BranchAudit.IssueActionPlanOwner on IssueActionPlanOwner.IssueActionPlanId = IssueActionPlan.Id
                        left join BranchAudit.IssueBranch on Issue.Id = IssueBranch.IssueId
                        left join Config.IssueOwner on Issue.Id = IssueOwner.IssueId
                        left join Config.CommonValueAndType as cvtStatus on cvtStatus.Id = Issue.StatusTypeId 
						left join Config.CommonValueAndType as cvtRating on cvtRating.Id = Issue.RatingTypeId
                        left join BranchAudit.AuditSchedule on AuditSchedule.Id = Issue.AuditScheduleId

                    where Issue.Id = @id and Issue.IsDeleted = 0";
        var parameters = new Dictionary<string, object> { { "id", id } };
        string splitters = "Id, Id, Id, Id";
        var issueList = new Dictionary<Guid, Issue>();
        var issueOwnersList = new Dictionary<Guid, IssueOwner>();
        var issueBranchesList = new Dictionary<Guid, IssueBranch>();
        var issueActionPlansList = new Dictionary<Guid, IssueActionPlan>();
        var issueActionPlansOwnerList = new Dictionary<Guid, IssueActionPlanOwner>();


        var data = await Get<Issue, IssueActionPlan, IssueActionPlanOwner, IssueBranch, IssueOwner, Issue >(query, (issue, issueActionPlan, issueActionPlanOwner, issueBranch, issueOwner) =>
        {
            Issue issueResult;
            if (!issueList.ContainsKey(issue.Id))
            {
                issueList.Add(issue.Id, issue);
                issueResult = issue;
                issueResult.ActionPlans = new List<IssueActionPlan>();
                issueResult.IssueBranchList = new List<IssueBranch>();
                issueResult.IssueOwnerList = new List<IssueOwner>();
            }
            else
            {
                issueResult = issueList[issue.Id];
            }
            //u.AuditCreation = auditcreation;
            if (!issueActionPlansList.ContainsKey(issueActionPlan.Id))
            {
                issueActionPlan.issueActionPlanOwnerList = new List<IssueActionPlanOwner>();
                issueActionPlansList.Add(issueActionPlan.Id, issueActionPlan);
                issueResult.ActionPlans.Add(issueActionPlan);
                issueResult.ActionPlans.FirstOrDefault().issueActionPlanOwnerList.Add(issueActionPlanOwner);
            }

            if (!issueBranchesList.ContainsKey(issueBranch.Id))
            {               
                issueBranchesList.Add(issueBranch.Id, issueBranch);
                issueResult.IssueBranchList.Add(issueBranch);
            }

            if (!issueOwnersList.ContainsKey(issueOwner.Id))
            {
                //issueActionPlan.issueActionPlanOwnerList = new List<IssueActionPlanOwner>();
                issueOwnersList.Add(issueOwner.Id, issueOwner);
                issueResult.IssueOwnerList.Add(issueOwner);
            }


            //if (!issueActionPlansOwnerList.ContainsKey(issueActionPlanOwner.Id))
            //{
            //    issueActionPlansOwnerList.Add(issueActionPlanOwner.Id, issueActionPlanOwner);

            //    issueActionPlan.issueActionPlanOwnerList = issueActionPlanOwner;
            //    issueActionPlansList.Add(issueActionPlan.Id, issueActionPlan);
            //    issueResult.ActionPlans.FirstOrDefault().issueActionPlanOwnerList.Add(issueActionPlan);
            //}

           
            return issueResult;
        }, parameters, splitters, false);
        return data.Distinct().FirstOrDefault();

       // return await Single(query2, parameters);
    }

}