using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Commands.UpdateDashboard;

public class UpdateDashboardCommand : IRequest<UpdateDashboardResponseDTO>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}
