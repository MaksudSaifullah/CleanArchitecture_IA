using Internal.Audit.Domain.Entities.BranchAudit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.WeightScoreConfigurations.Queries.WeightScoreByCountryId;
public record GetWeightScoreQuery(Guid countryId) : IRequest<WeightScoreByCountryIdDTO>;
