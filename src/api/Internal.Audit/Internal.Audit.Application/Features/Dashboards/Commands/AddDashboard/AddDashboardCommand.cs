using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Commands.AddDashboard;

public class AddDashboardCommand : IRequest<AddDashboardResponseDTO>
{
    public string Name { get; set; }
    public bool Status { get; set; }
}
