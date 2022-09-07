using MediatR;

namespace Internal.Audit.Application.Features.Issues.Commands.AddIssue
{
    public class AddIssueCommand : IRequest<AddIssueResponseDTO>
    {
        public string Code { get; set; } = null!;
        public Guid AuditScheduleId { get; set; }
        public Guid ImpactTypeId { get; set; }
        public Guid LikelihoodTypeId { get; set; }
        public Guid RatingTypeId { get; set; }
        public Guid StatusTypeId { get; set; } = new Guid("0B838C61-2F0E-ED11-B3B2-00155D610B18");
        public string IssueTitle { get; set; } = null!;
        public string Policy { get; set; } = null!;
        public DateTime TargetDate { get; set; }
        public string Details { get; set; } = null!;
        public string RootCause { get; set; } = null!;
        public string BusinessImpact { get; set; } = null!;
        public string PotentialRisk { get; set; } = null!;
        public string AuditorRecommendation { get; set; } = null!;
        public string? Remarks { get; set; }

        public List<AddIssueBranchCommand> IssueBranchList { get; set; }
        public List<AddIssueOwnerCommand> IssueOwnerList { get; set; }
        public List<AddIssueActionPlanCommand> ActionPlans { get; set; }
    }
    public record AddIssueBranchCommand
    {
        public Guid? Id { get; set; }
        public Guid IssueId { get; set; }
        public Guid BranchId { get; set; }
    }

    public record AddIssueOwnerCommand
    {
        public Guid? Id { get; set; }
        public Guid IssueId { get; set; }
        public Guid OwnerId { get; set; }
    }
    public record AddIssueActionPlanCommand
    {
        public Guid? Id { get; set; }
        public string? ActionPlanCode { get; set; } = null!;
        public Guid? IssueId { get; set; }
        public List<AddIssueActionOwnerListCommand>? issueActionPlanOwnerList { get; set; }
        public Guid? EvidenceDocumentId { get; set; }
        public string? ManagementPlan { get; set; } = null!;
        public DateTime? TargetDate { get; set; }
        public bool? IsActionTaken { get; set; } = false;
        public DateTime? ActionTakenDate { get; set; }
        public string? ActionTakenRemarks { get; set; }

    }
    public class AddIssueActionOwnerListCommand
    {
        public Guid? Id { get; set; }
        public Guid? IssueActionPlanId { get; set; }
        public Guid OwnerId { get; set; }
    }
}