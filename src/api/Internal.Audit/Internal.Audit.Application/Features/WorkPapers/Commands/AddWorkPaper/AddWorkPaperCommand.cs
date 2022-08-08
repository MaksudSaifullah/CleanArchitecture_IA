using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WorkPapers.Commands.AddWorkPaper;

public class AddWorkPaperCommand : IRequest<AddWorkPaperResponseDTO>
{
    public string? WorkPaperCode { get; set; }
    public string? ScheduleCode { get; set; }
    public Guid AuditScheduleId { get; set; }
    public string? TopicHeadName { get; set; }
    public string? QuestionName { get; set; }
    public Guid TopicHeadId { get; set; }
    public string? BranchName { get; set; }
    public Guid BranchId { get; set; }
    public string? SampleName { get; set; }
    public string? SampleMonth { get; set; }
    public Guid SampleMonthId { get; set; }
    public string? SampleSelectionMethod { get; set; }
    public Guid SampleSelectionMethodId { get; set; }
    public string? ControlActivityNature { get; set; }
    public Guid ControlActivityNatureId { get; set; }
    public string? ControlFrequency { get; set; }
    public Guid ControlFrequencyId { get; set; }
    public string? SampleSize { get; set; }
    public Guid SampleSizeId { get; set; }
    public string? TestingDetails { get; set; }
    public string? TestingResults { get; set; }
    public string? TestingConclusion { get; set; }
    public Guid TestingConclusionId { get; set; }
    public string? DocumentName { get; set; }
    public Guid DocumentId { get; set; }
}
