using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Queries.GetRiskCriteriaById;
public record GetRiskCriteriaPCAQuery(Guid Id) : IRequest<RiskCriteriaPCAByIdDTO>;