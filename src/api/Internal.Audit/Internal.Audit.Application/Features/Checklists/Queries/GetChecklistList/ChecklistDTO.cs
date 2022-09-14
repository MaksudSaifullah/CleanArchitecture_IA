using System;
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
    public string? AuditScheduleBranchName { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
}