﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.UpdateAuditPlan;

public class UpdateAuditPlanCommand : IRequest<UpdateAuditPlanResponseDTO>
{
    public Guid Id { get; set; }
    public Guid RiskAssesmentId { get; set; }
    public string? PlanCode { get; set; }
    public Guid PlanningYearId { get; set; }
    public DateTime AssesmentFrom { get; set; }
    public DateTime AssesmentTo { get; set; }
}

