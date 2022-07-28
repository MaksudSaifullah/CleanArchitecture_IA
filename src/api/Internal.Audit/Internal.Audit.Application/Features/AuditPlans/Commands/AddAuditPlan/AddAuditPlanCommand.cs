using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.AddAuditPlan;

public class AddAuditPlanCommand : IRequest<AddAuditPlanResponseDTO>
{
    public Guid CountryId { get; set; }
    public Guid AuditTypeId { get; set; }
    public Guid RiskAssesmentId { get; set; }
    public string? AssesmentCode { get; set; }
    public string? PlanningYear { get; set; }
    public DateTime AssesmentFrom { get; set; }
    public DateTime AssesmentTo { get; set; }
}
