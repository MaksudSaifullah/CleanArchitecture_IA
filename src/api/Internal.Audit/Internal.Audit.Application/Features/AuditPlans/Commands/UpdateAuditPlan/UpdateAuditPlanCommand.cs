using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.UpdateAuditPlan;

public class UpdateAuditPlanCommand : IRequest<UpdateAuditPlanResponseDTO>
{
    public Guid Id { get; set; }
    public Guid RiskAssessmentId { get; set; }
    public string? PlanCode { get; set; }
    public Guid PlanningYearId { get; set; }
    public DateTime AssessmentFrom { get; set; }
    public DateTime AssessmentTo { get; set; }
}

