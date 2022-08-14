using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Commands.UpdateWorkPaper;

public class UpdateWorkPaperCommand : IRequest<UpdateWorkPaperResponseDTO>
{
    public Guid Id { get; set; }
    public string? WorkPaperCode { get; set; }
    public Guid AuditScheduleId { get; set; }
    public Guid TopicHeadId { get; set; }
    public Guid QuestionId { get; set; }
    public Guid BranchId { get; set; }
    public string? SampleName { get; set; }
    public Guid SampleMonthId { get; set; }
    public Guid SampleSelectionMethodId { get; set; }
    public Guid ControlActivityNatureId { get; set; }
    public Guid ControlFrequencyId { get; set; }
    public Guid SampleSizeId { get; set; }
    public string? TestingDetails { get; set; } = null!;
    public string? TestingResults { get; set; } = null!;
    public Guid TestingConclusionId { get; set; }
    public Guid DocumentId { get; set; }
    public DateTime TestingDate { get; set; }
}

