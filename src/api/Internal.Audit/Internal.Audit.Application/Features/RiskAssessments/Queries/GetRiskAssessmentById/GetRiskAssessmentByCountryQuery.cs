using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Internal.Audit.Application.Features.RiskAssessments.Queries.GetRiskAssessmentById;


public record GetRiskAssessmentByCountryQuery(Guid Id) : IRequest<IEnumerable<RiskAssessmentByIdDTO>>;