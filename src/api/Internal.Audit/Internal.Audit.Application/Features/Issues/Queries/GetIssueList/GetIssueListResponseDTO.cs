namespace Internal.Audit.Application.Features.Issues.Queries.GetIssueList;
public record GetIssueListResponseDTO
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string IssueTitle { get; set; } = null!;
    public DateTime TargetDate { get; set; }

    //public string Policy { get; set; } = null!;
    //public string Details { get; set; } = null!;
    //public string RootCause { get; set; } = null!;
    //public string BusinessImpact { get; set; } = null!;
    //public string PotentialRisk { get; set; } = null!;
    //public string AuditorRecommendation { get; set; } = null!;
    //public string? Remarks { get; set; }
    //public string? AuditScheduleName { get; set; }
    //public string? BranchName { get; set; }
    //public string? ImpactTypeName { get; set; }
    //public string? LikelihoodTypeName { get; set; }

    public string IssueOwners { get; set; } = null!;
    public string ActionOwners { get; set; } = null!;
    public string? RatingType { get; set; }    
    public string? StatusType { get; set; }
}
