using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Issues.Queries.GetIssueById;
public record GetIssueByIdResponseDTO
{

    //public Guid Id { get; set; }
    //public string Code { get; set; }
    //public string IssueTitle { get; set; } = null!;
    //public DateTime TargetDate { get; set; }

    //public string Policy { get; set; } = null!;
    //public string Details { get; set; } = null!;
    //public string RootCause { get; set; } = null!;
    //public string BusinessImpact { get; set; } = null!;
    //public string PotentialRisk { get; set; } = null!;
    //public string AuditorRecommendation { get; set; } = null!;
    //public string? Remarks { get; set; }
    //public string? AuditScheduleName { get; set; }
    //public string? Branch { get; set; }
    //public string? ImpactType { get; set; }
    //public string? LikelihoodType { get; set; }
    //public string? RatingType { get; set; }
    //public string? StatusType { get; set; }
    //public string IssueOwners { get; set; } = null!;
    //public string ActionOwners { get; set; } = null!;


    public Guid Id { get; set; }
    public string Code { get; set; } = null!;
    public Guid AuditScheduleId { get; set; }
    public Guid ImpactTypeId { get; set; }
    public Guid LikelihoodTypeId { get; set; }
    public Guid RatingTypeId { get; set; }
    public Guid StatusTypeId { get; set; }
    public string IssueTitle { get; set; } = null!;
    public string Policy { get; set; } = null!;
    public DateTime TargetDate { get; set; }
    public string Details { get; set; } = null!;
    public string RootCause { get; set; } = null!;
    public string BusinessImpact { get; set; } = null!;
    public string PotentialRisk { get; set; } = null!;
    public string AuditorRecommendation { get; set; } = null!;
    public string? Remarks { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? RatingType { get; set; }
    public string? StatusType { get; set; }
    public string? IssueOwners { get; set; }
    public string? Branches { get; set; }
    public string? AuditScheduleCode { get; set; }


    public List<GetIssueBranch> IssueBranchList { get; set; }
    public List<GetIssueOwner> IssueOwnerList { get; set; }
    public List<GetIssueActionPlan> ActionPlans { get; set; }
}
public record GetIssueBranch
{
    public Guid Id { get; set; }
    public Guid IssueId { get; set; }
    public Guid BranchId { get; set; }
}

public record GetIssueOwner
{
    public Guid Id { get; set; }
    public Guid IssueId { get; set; }
    public Guid OwnerId { get; set; }
}
public record GetIssueActionPlan
{
    public Guid Id { get; set; }
    public string ActionPlanCode { get; set; } = null!;
    public Guid? IssueId { get; set; }
    public List<GetIssueActionOwnerList> issueActionPlanOwnerList { get; set; }
    public Guid? EvidenceDocumentId { get; set; }
    public string? ManagementPlan { get; set; } = null!;
    public DateTime? TargetDate { get; set; }
    public bool? IsActionTaken { get; set; } = false;
    public DateTime? ActionTakenDate { get; set; }
    public string? ActionTakenRemarks { get; set; }
    public string? IssueActionPlanOwners { get; set; }

}
public class GetIssueActionOwnerList
{
    public Guid Id { get; set; }
    public Guid IssueActionPlanId { get; set; }
    public Guid OwnerId { get; set; }
}
