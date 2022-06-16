using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.Dashboards.Commands.DeleteDashboard;
public class DeleteDashboardCommand : IRequest<DeleteDashboardResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteDashboardCommand(Guid id)
    {
        Id = id;
    }
}
