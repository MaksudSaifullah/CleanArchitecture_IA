using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internal.Audit.Application.Features.RiskProfiles.Commands.DeleteRiskProfile;

public class DeleteRiskProfileCommand : IRequest<DeleteRiskProfileResponseDTO>
{
    public Guid Id { get; set; }
    public DeleteRiskProfileCommand(Guid id)
    {
        Id = id;
    }
}
