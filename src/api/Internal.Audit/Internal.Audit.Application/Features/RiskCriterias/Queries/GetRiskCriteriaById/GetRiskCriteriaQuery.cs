using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Queries.GetRiskCriteriaById;
public record GetRiskCriteriaQuery(Guid Id) : IRequest<RiskCriteriaByIdDTO>;