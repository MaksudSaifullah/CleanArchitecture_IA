using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.AddAuditPlan;

public class AddAuditPlanCommand : IRequest<AddAuditPlanResponseDTO>
{
    public Guid RiskAssessmentId { get; set; }
    public string? PlanCode { get; set; }
    public Guid PlanningYearId { get; set; }
    public DateTime AssessmentFrom { get; set; }
    public DateTime AssessmentTo { get; set; }
}
