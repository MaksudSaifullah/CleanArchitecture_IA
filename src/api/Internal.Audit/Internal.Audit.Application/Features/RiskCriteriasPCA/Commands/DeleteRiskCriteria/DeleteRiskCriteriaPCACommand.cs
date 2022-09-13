using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriteriasPCA.Commands.DeleteRiskCriteria;

public class DeleteRiskCriteriaPCACommand : IRequest<DeleteRiskCriteriaPCAResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteRiskCriteriaPCACommand(Guid id)
    {
        Id = id;
    }
}
