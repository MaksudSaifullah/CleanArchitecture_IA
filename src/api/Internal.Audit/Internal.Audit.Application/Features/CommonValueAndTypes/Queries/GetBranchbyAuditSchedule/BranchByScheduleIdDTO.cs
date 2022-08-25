using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.CommonValueAndTypes.Queries.GetBranchbyAuditSchedule;

public record BranchByScheduleIdDTO
{
    public Guid Id { get; set; }
    public Guid AuditScheduleId { get; set; }
    public BranchDTO Branch { get; set; }

}
public class BranchDTO
{
    public Guid Id { get; set; }
    public long BranchId { get; set; }
    public int BranchCode { get; set; }
    public string? BranchName { get; set; }
}