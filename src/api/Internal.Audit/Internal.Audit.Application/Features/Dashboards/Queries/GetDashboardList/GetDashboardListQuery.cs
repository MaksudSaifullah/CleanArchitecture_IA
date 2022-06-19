using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Queries.GetDashboardList;
public class GetDashboardListQuery : IRequest<List<DashboardDTO>>
{
}
