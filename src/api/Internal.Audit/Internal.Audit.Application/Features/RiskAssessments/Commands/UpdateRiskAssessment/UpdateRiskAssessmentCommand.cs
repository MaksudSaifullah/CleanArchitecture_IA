﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Commands.UpdateRiskAssessment;

public class UpdateRiskAssessmentCommand : IRequest<UpdateRiskAssessmentResponseDTO>
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid AuditTypeId { get; set; }
    public string AssessmentCode { get; set; } = null!;
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTo { get; set; }
}

