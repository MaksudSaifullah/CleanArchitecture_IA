﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Checklists.Queries.GetChecklistList;

public record ChecklistDTO
{
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
}