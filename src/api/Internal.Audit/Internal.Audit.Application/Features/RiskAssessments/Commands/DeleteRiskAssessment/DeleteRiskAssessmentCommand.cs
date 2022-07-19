using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskAssessments.Commands.DeleteRiskAssessment;

public class DeleteRiskAssessmentCommand : IRequest<DeleteRiskAssessmentResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteRiskAssessmentCommand(Guid id)
    {
        Id = id;
    }
}
