using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskCriterias.Commands.DeleteRiskCriteria;

public class DeleteRiskCriteriaCommand : IRequest<DeleteRiskCriteriaResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteRiskCriteriaCommand(Guid id)
    {
        Id = id;
    }
}
