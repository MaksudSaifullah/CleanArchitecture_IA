using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.IssueValidationActionPlans.Commands.DeleteActionPlans;

public record DeleteActionPlanCommand(Guid Id):IRequest<DeleteActionPlanCommandResponseDTO>;

