using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.AuditPlans.Commands.DeleteAuditPlan;

public class DeleteAuditPlanCommand : IRequest<DeleteAuditPlanResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteAuditPlanCommand(Guid id)
    {
        Id = id;
    }
}
