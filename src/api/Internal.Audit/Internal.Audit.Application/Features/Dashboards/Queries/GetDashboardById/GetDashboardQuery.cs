using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardById;
public record GetDashboardQuery(Guid Id) : IRequest<DashboardByIdDTO>;


