﻿using Internal.Audit.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Domain.CompositeEntities.BranchAudit;
public class CompositeWorkPaper : EntityBase
{
    public string? WorkPaperCode { get; set; }
    public string? ScheduleCode { get; set; }
    public Guid AuditScheduleId { get; set; }
    public string? TopicHeadName { get; set; }
    public string? QuestionName { get; set; }
    public Guid TopicHeadId { get; set; }
    public Guid QuestionId { get; set; }
    public string? BranchName { get; set; }
    public Guid AuditScheduleBranchId { get; set; }
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
    public DateTime TestingDate { get; set; }
    public DateTime ScheduleStartDate { get; set; }
    public DateTime ScheduleEndDate { get; set; }

}