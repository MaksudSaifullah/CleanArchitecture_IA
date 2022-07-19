using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentById;
public record GetRiskAssessmentQuery(Guid Id) : IRequest<RiskAssessmentByIdDTO>;
