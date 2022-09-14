using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Commands.AddChecklist;

public class AddChecklistCommand : IRequest<AddChecklistResponseDTO>
{
    public Guid? Id { get; set; }
    public string? ChecklistCode { get; set; }
    public Guid AuditScheduleId { get; set; }
    public Guid AuditScheduleBranchId { get; set; }
    public Guid RegionId { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime DisbursementDate { get; set; }
    public string? BranchManagerName { get; set; }
    public DateTime BMJoiningDate { get; set; }
    public DateTime AuditDate { get; set; }
    public string? AuditOn { get; set; }
    public DateTime LastAuditFromDate { get; set; }
    public DateTime LastAuditToDate { get; set; }
    public bool IsDraft { get; set; }

    public List<AddChecklistTopic> ChecklistTopicHeads { get; set; }
   // public List<AddChecklistTopicDetail> ChecklistTopicDetail { get; set; }

}


public record AddChecklistTopic
{
    //public Guid? Id { get; set; }
    public Guid TopicHeadId { get; set; }

    public Guid ChecklistId { get; set; }

    public List<AddChecklistTopicDetail> ChecklistTopicHeadDetails { get; set; }

}

public record AddChecklistTopicDetail
{

    public Guid ChecklistTopicId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid TestStepId { get; set; }
    public Guid DocumentId { get; set; }

    public string? TestingResult { get; set; }

    public string? TestingConclusion { get; set; }

    public int TotalScore { get; set; }
    public int ObtainedScore { get; set; }
    public int Weight { get; set; }
    public int WeightedScore { get; set; }


}

